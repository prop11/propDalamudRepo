using AetherCurrents.Data;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface;
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
               ImGuiWindowFlags.NoFocusOnAppearing)
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

    private static float GetZoomMultiplier(float zoomIndex, float uiScale)
    {
        var x = Math.Clamp(zoomIndex, 0f, 7f);
        return (((107f * x * x) + x + 750f) / 3000f) * uiScale;
    }

    private static float DisplayCoordToWorld(float displayCoord, float sizeFactor)
    {
        var c = sizeFactor / 100.0f;
        return ((displayCoord - 1.0f) * c * (41.0f / 40.0f) * 50.0f) - (c * 1024.0f);
    }

    public override void Draw()
    {
        if (!Plugin.ClientState.IsLoggedIn) return;

        var areaMapPtr = Plugin.GameGui.GetAddonByName("AreaMap");
        if (areaMapPtr == nint.Zero) return;

        // FIX: Use .Address to get native pointer from Dalamud wrapper
        var areaMap = (AtkUnitBase*)areaMapPtr.Address;
        if (areaMap == null || !areaMap->IsVisible) return;
        if (areaMap->UldManager.LoadedState != AtkLoadState.Loaded) return;

        var agentMap = AgentMap.Instance();
        if (agentMap == null || agentMap->CurrentMapId == 0) return;

        var zoneSizeFactor = agentMap->SelectedMapSizeFactorFloat;

        var zone = AetherCurrentDatabase.GetZoneByName(Plugin.Configuration.SelectedZone);
        if (zone == null) return;

        // STEP 1: Find player marker node
        var imageNode = (AtkImageNode*)Marshal.ReadIntPtr((nint)areaMap, 0x3B8);
        if (imageNode == null) return;

        // STEP 2: Calculate mapCenterScreenPos
        var resNode = &imageNode->AtkResNode;
        var mapOffsetX = 16.0f * areaMap->Scale;
        var mapOffsetY = 52.0f * areaMap->Scale;

        float nodeX, nodeY;
        resNode->GetPositionFloat(&nodeX, &nodeY);

        var playerMarkerCenterX = nodeX + (resNode->Width / 2f * resNode->ScaleX);
        var playerMarkerCenterY = nodeY + (resNode->Height / 2f * resNode->ScaleY);

        var playerScreenX = areaMap->X - mapOffsetX + (playerMarkerCenterX * areaMap->Scale);
        var playerScreenY = areaMap->Y + mapOffsetY + (playerMarkerCenterY * areaMap->Scale);

        var sliderNode = (AtkComponentNode*)areaMap->GetNodeById(16);
        float zoomIndex = 0f;
        if (sliderNode != null)
        {
            var sliderComponent = (AtkComponentSlider*)sliderNode->GetComponent();
            if (sliderComponent != null)
                zoomIndex = sliderComponent->Value;
        }

        var multiplier = GetZoomMultiplier(zoomIndex, areaMap->Scale);

        var player = Plugin.ObjectTable.LocalPlayer;
        if (player == null) return;

        var playerWorldX = player.Position.X * zoneSizeFactor * multiplier;
        var playerWorldZ = player.Position.Z * zoneSizeFactor * multiplier;

        var mapCenterScreenPos = new Vector2(
            playerScreenX - playerWorldX,
            playerScreenY - playerWorldZ
        );

        // STEP 3: Get clip bounds
        var mapComponent = areaMap->GetComponentNodeById(53);
        if (mapComponent == null) return;

        var clipNode = mapComponent->Component->UldManager.SearchNodeById(0);
        if (clipNode == null)
            clipNode = &mapComponent->AtkResNode;

        float mapBoxX, mapBoxY;
        clipNode->GetPositionFloat(&mapBoxX, &mapBoxY);

        var mapMinX = areaMap->X + (mapBoxX * areaMap->Scale);
        var mapMinY = areaMap->Y + (mapBoxY * areaMap->Scale);
        var mapMaxX = mapMinX + (clipNode->Width * clipNode->ScaleX * areaMap->Scale);
        var mapMaxY = mapMinY + (clipNode->Height * clipNode->ScaleY * areaMap->Scale);

        // STEP 4: Draw markers
        var drawList = ImGui.GetWindowDrawList();
        var cfg = Plugin.Configuration;

        drawList.PushClipRect(new Vector2(mapMinX, mapMinY), new Vector2(mapMaxX, mapMaxY), true);

        foreach (var current in zone.Currents)
        {
            if (current.Type == CurrentType.Field && !cfg.ShowFieldCurrents) continue;
            if (current.Type == CurrentType.Quest && !cfg.ShowQuestCurrents) continue;

            var worldX = DisplayCoordToWorld(current.X, zoneSizeFactor * 100f);
            var worldZ = DisplayCoordToWorld(current.Y, zoneSizeFactor * 100f);

            var sx = mapCenterScreenPos.X + (worldX * zoneSizeFactor * multiplier);
            var sy = mapCenterScreenPos.Y + (worldZ * zoneSizeFactor * multiplier);

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