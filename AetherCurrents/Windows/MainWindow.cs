using AetherCurrents.Data;
using Dalamud.Bindings.ImGui;
using Dalamud.Interface;
using Dalamud.Interface.Windowing;
using System;
using System.Linq;
using System.Numerics;

namespace AetherCurrents.Windows;

public class MainWindow : Window, IDisposable
{
    private readonly Plugin Plugin;

    public MainWindow(Plugin plugin)
        : base("Aether Currents##AetherCurrentsMain",
              ImGuiWindowFlags.NoScrollbar | ImGuiWindowFlags.NoScrollWithMouse)
    {
        Plugin = plugin;

        SizeConstraints = new WindowSizeConstraints
        {
            MinimumSize = new Vector2(340, 420),
            MaximumSize = new Vector2(500, 700),
        };
    }

    public void Dispose() { }

    public override void Draw()
    {
        var cfg = Plugin.Configuration;

        ImGui.TextColored(new Vector4(0.6f, 0.9f, 1.0f, 1f), "Aether Current Tracker");
        ImGui.Separator();
        ImGui.Spacing();

        // Expansion selector
        ImGui.Text("Expansion:");
        ImGui.SameLine();
        ImGui.SetNextItemWidth(180f);
        if (ImGui.BeginCombo("##expansion", cfg.SelectedExpansion))
        {
            foreach (var exp in AetherCurrentDatabase.Expansions())
            {
                bool selected = exp == cfg.SelectedExpansion;
                if (ImGui.Selectable(exp, selected))
                {
                    cfg.SelectedExpansion = exp;
                    var zones = AetherCurrentDatabase.GetZones(exp).ToList();
                    if (zones.Any())
                    {
                        cfg.SelectedZone = zones.First().Name;
                    }
                    cfg.Save();
                }
                if (selected) ImGui.SetItemDefaultFocus();
            }
            ImGui.EndCombo();
        }

        ImGui.Spacing();

        // Zone selector
        ImGui.Text("Zone:");
        ImGui.SameLine();
        ImGui.SetNextItemWidth(230f);
        if (ImGui.BeginCombo("##zone", cfg.SelectedZone))
        {
            foreach (var zone in AetherCurrentDatabase.GetZones(cfg.SelectedExpansion))
            {
                bool selected = zone.Name == cfg.SelectedZone;
                if (ImGui.Selectable(zone.Name, selected))
                {
                    cfg.SelectedZone = zone.Name;
                    cfg.Save();
                }
                if (selected) ImGui.SetItemDefaultFocus();
            }
            ImGui.EndCombo();
        }

        ImGui.Spacing();
        ImGui.Separator();
        ImGui.Spacing();

        // Display options
        bool showField = cfg.ShowFieldCurrents;
        if (ImGui.Checkbox("Show Field Currents", ref showField))
        {
            cfg.ShowFieldCurrents = showField;
            cfg.Save();
        }

        bool showQuest = cfg.ShowQuestCurrents;
        if (ImGui.Checkbox("Show Quest Currents", ref showQuest))
        {
            cfg.ShowQuestCurrents = showQuest;
            cfg.Save();
        }

        float scale = cfg.MarkerScale;
        ImGui.SetNextItemWidth(160f);
        if (ImGui.SliderFloat("Marker Size", ref scale, 0.5f, 2.5f, "%.1fx"))
        {
            cfg.MarkerScale = scale;
            cfg.Save();
        }

        ImGui.Spacing();
        ImGui.Separator();

        var selectedZone = AetherCurrentDatabase.GetZoneByName(cfg.SelectedZone);
        if (selectedZone == null) return;

        // Use child window with border
        if (ImGui.BeginChild("##currentList", new Vector2(0, 0), true))
        {
            foreach (var current in selectedZone.Currents)
            {
                if (current.Type == CurrentType.Field && !cfg.ShowFieldCurrents) continue;
                if (current.Type == CurrentType.Quest && !cfg.ShowQuestCurrents) continue;

                var color = current.Type == CurrentType.Field
                    ? new Vector4(0.2f, 0.9f, 0.3f, 1f)
                    : new Vector4(1.0f, 0.85f, 0.1f, 1f);

                ImGui.TextColored(color, "●");
                ImGui.SameLine();
                ImGui.Text($"({current.X:F1}, {current.Y:F1}) {current.Description}");
            }
            ImGui.EndChild();
        }
    }
}