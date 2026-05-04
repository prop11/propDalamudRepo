using Dalamud.Configuration;
using Dalamud.Plugin;
using System;

namespace AetherCurrents;

[Serializable]
public class Configuration : IPluginConfiguration
{
    public int Version { get; set; } = 1;

    // Which expansion to show on the map
    public string SelectedExpansion { get; set; } = "Heavensward";

    // Which zone within the expansion
    public string SelectedZone { get; set; } = "Coerthas Western Highlands";

    // Whether to show field currents (green orbs)
    public bool ShowFieldCurrents { get; set; } = true;

    // Whether to show quest currents (yellow icons)
    public bool ShowQuestCurrents { get; set; } = true;

    // Whether to show already-attuned (read from game state) - future feature stub
    public bool HideAttuned { get; set; } = false;

    // Marker size multiplier
    public float MarkerScale { get; set; } = 1.0f;

    [NonSerialized]
    private IDalamudPluginInterface? PluginInterface;

    public void Initialize(IDalamudPluginInterface pluginInterface)
    {
        PluginInterface = pluginInterface;
    }

    public void Save()
    {
        PluginInterface!.SavePluginConfig(this);
    }
}