using AetherCurrents.Data;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface.Utility;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin.Services;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using FFXIVClientStructs.FFXIV.Component.GUI;
using System;
using System.Numerics;
using System.Runtime.InteropServices;

namespace AetherCurrents.Windows;

public sealed unsafe class MapOverlayWindow : Window, IDisposable
{
    private readonly Plugin Plugin;
    private readonly IPluginLog Log;

    private static readonly Vector4 FieldColour = new(0.2f, 0.95f, 0.3f, 1.0f);
    private static readonly Vector4 QuestColour = new(1.0f, 0.85f, 0.1f, 1.0f);
    private static readonly Vector4 ShadowColour = new(0.0f, 0.0f, 0.0f, 0.55f);

    public MapOverlayWindow(Plugin plugin, IPluginLog log)
        : base("##AetherCurrentsMapOverlay",
               ImGuiWindowFlags.NoTitleBar |
               ImGuiWindowFlags.NoResize |
               ImGuiWindowFlags.NoInputs |
               ImGuiWindowFlags.NoBackground |
               ImGuiWindowFlags.NoSavedSettings |
               ImGuiWindowFlags.NoBringToFrontOnFocus |
               ImGuiWindowFlags.NoFocusOnAppearing |
               ImGuiWindowFlags.NoScrollbar |
               ImGuiWindowFlags.NoScrollWithMouse)
    {
        Plugin = plugin;
        Log = log;
        IsOpen = true;
        RespectCloseHotkey = false;
        Position = Vector2.Zero;
        PositionCondition = ImGuiCond.Always;
    }

    public void Dispose() { }

    public override void PreDraw()
    {
        ImGui.SetNextWindowPos(Vector2.Zero);
        ImGui.SetNextWindowSize(ImGui.GetIO().DisplaySize);
    }

    private static float ZoomMultiplier(float zoomIndex, float uiScale)
    {
        float x = Math.Clamp(zoomIndex, 0f, 7f);
        return (((107f * x * x) + x + 750f) / 3000f) * uiScale;
    }

    private static float DisplayCoordToWorld(float displayCoord, float sizeFactor)
    {
        float c = sizeFactor / 100f;
        return (displayCoord - 1f) * c * 50f - c * 1024f;
    }

    public override void Draw()
    {
        if (!Plugin.ClientState.IsLoggedIn) return;

        var areaMapPtr = Plugin.GameGui.GetAddonByName("AreaMap");
        if (areaMapPtr == nint.Zero) return;

        var areaMap = (AtkUnitBase*)areaMapPtr.Address;
        if (areaMap == null || !areaMap->IsVisible) return;
        if (areaMap->UldManager.LoadedState != AtkLoadState.Loaded) return;

        var agentMap = AgentMap.Instance();
        if (agentMap == null || agentMap->CurrentMapId == 0) return;

        float zoneSizeFactor = agentMap->SelectedMapSizeFactorFloat;

        var zone = AetherCurrentDatabase.GetZoneByName(Plugin.Configuration.SelectedZone);
        if (zone == null) return;

        // Read zoom slider
        float zoomIndex = 0f;
        var sliderNode = (AtkComponentNode*)areaMap->GetNodeById(16);
        if (sliderNode != null)
        {
            var sliderComp = (AtkComponentSlider*)sliderNode->GetComponent();
            if (sliderComp != null)
                zoomIndex = sliderComp->Value;
        }

        float multiplier = ZoomMultiplier(zoomIndex, areaMap->Scale);

        var player = Plugin.ObjectTable.LocalPlayer;
        if (player == null) return;

        // Recalculate map center EVERY frame - needed for pan tracking
        var imageNode = (AtkImageNode*)Marshal.ReadIntPtr((nint)areaMap, 0x3B8);
        if (imageNode == null) return;

        var resNode = &imageNode->AtkResNode;

        float nodeX, nodeY;
        resNode->GetPositionFloat(&nodeX, &nodeY);

        float playerMarkerCX = nodeX + (resNode->Width / 2f * resNode->ScaleX);
        float playerMarkerCY = nodeY + (resNode->Height / 2f * resNode->ScaleY);

        float mapOffsetX = 16f * areaMap->Scale;
        float mapOffsetY = 52f * areaMap->Scale;

        float playerScreenX = areaMap->X - mapOffsetX + (playerMarkerCX * areaMap->Scale);
        float playerScreenY = areaMap->Y + mapOffsetY + (playerMarkerCY * areaMap->Scale);

        Vector2 mapCenter = new(
            playerScreenX - player.Position.X * zoneSizeFactor * multiplier,
            playerScreenY - player.Position.Z * zoneSizeFactor * multiplier
        );

        // Clip bounds from component node 53
        var mapComponent = areaMap->GetComponentNodeById(53);
        if (mapComponent == null) return;

        AtkResNode* clipNode = mapComponent->Component->UldManager.SearchNodeById(0);
        if (clipNode == null) clipNode = &mapComponent->AtkResNode;

        float boxX, boxY;
        clipNode->GetPositionFloat(&boxX, &boxY);

        float mapMinX = areaMap->X + (boxX * areaMap->Scale);
        float mapMinY = areaMap->Y + (boxY * areaMap->Scale);
        float mapMaxX = mapMinX + (clipNode->Width * clipNode->ScaleX * areaMap->Scale);
        float mapMaxY = mapMinY + (clipNode->Height * clipNode->ScaleY * areaMap->Scale);

        var drawList = ImGui.GetWindowDrawList();
        var cfg = Plugin.Configuration;

        drawList.PushClipRect(new Vector2(mapMinX, mapMinY), new Vector2(mapMaxX, mapMaxY), true);

        foreach (var current in zone.Currents)
        {
            if (current.Type == CurrentType.Field && !cfg.ShowFieldCurrents) continue;
            if (current.Type == CurrentType.Quest && !cfg.ShowQuestCurrents) continue;

            float worldX = DisplayCoordToWorld(current.X, zoneSizeFactor * 100f);
            float worldZ = DisplayCoordToWorld(current.Y, zoneSizeFactor * 100f);

            float sx = mapCenter.X + (worldX * zoneSizeFactor * multiplier);
            float sy = mapCenter.Y + (worldZ * zoneSizeFactor * multiplier);

            if (sx < mapMinX || sx > mapMaxX || sy < mapMinY || sy > mapMaxY) continue;

            var centre = new Vector2(sx, sy);
            float r = 8f * cfg.MarkerScale * ImGuiHelpers.GlobalScale;

            uint mainCol = ImGui.ColorConvertFloat4ToU32(
                current.Type == CurrentType.Field ? FieldColour : QuestColour);
            uint shadowCol = ImGui.ColorConvertFloat4ToU32(ShadowColour);

            drawList.AddCircleFilled(centre + new Vector2(1.5f, 1.5f), r, shadowCol);
            drawList.AddCircleFilled(centre, r, mainCol);
            drawList.AddCircle(centre, r, 0xCCFFFFFF, 0, 1.5f);
            drawList.AddCircleFilled(centre, r * 0.3f, 0xFFFFFFFF);
        }

        drawList.PopClipRect();
    }
}