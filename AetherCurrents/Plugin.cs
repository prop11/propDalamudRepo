using AetherCurrents.Windows;
using Dalamud.Game.Command;
using Dalamud.Interface.Windowing;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace AetherCurrents;

public sealed class Plugin : IDalamudPlugin
{
    public string Name => "Aether Currents";

    private const string CommandName = "/aethercurrents";
    private const string ShortCommandName = "/ac";

    public Configuration Configuration { get; init; }
    public WindowSystem WindowSystem = new("AetherCurrents");
    public MainWindow MainWindow { get; init; }
    public MapOverlayWindow MapOverlay { get; init; }

    public static IDalamudPluginInterface PluginInterface { get; private set; } = null!;
    public static IClientState ClientState { get; private set; } = null!;
    public static IGameGui GameGui { get; private set; } = null!;
    public static IObjectTable ObjectTable { get; private set; } = null!;
    public static IPluginLog Log { get; private set; } = null!;

    private readonly ICommandManager _commandManager;

    public Plugin(
        IDalamudPluginInterface pluginInterface,
        ICommandManager commandManager,
        IClientState clientState,
        IGameGui gameGui,
        IObjectTable objectTable,
        IPluginLog log)
    {
        PluginInterface = pluginInterface;
        ClientState = clientState;
        GameGui = gameGui;
        ObjectTable = objectTable;
        Log = log;
        _commandManager = commandManager;

        Configuration = pluginInterface.GetPluginConfig() as Configuration ?? new Configuration();
        Configuration.Initialize(pluginInterface);

        MainWindow = new MainWindow(this);
        MapOverlay = new MapOverlayWindow(this, log);

        WindowSystem.AddWindow(MainWindow);
        WindowSystem.AddWindow(MapOverlay);

        commandManager.AddHandler(CommandName, new CommandInfo(OnCommand)
        {
            HelpMessage = "Open the Aether Currents configuration window."
        });
        commandManager.AddHandler(ShortCommandName, new CommandInfo(OnCommand)
        {
            HelpMessage = "Open the Aether Currents configuration window."
        });

        pluginInterface.UiBuilder.Draw += DrawUI;
        pluginInterface.UiBuilder.OpenConfigUi += DrawConfigUI;
    }

    public void Dispose()
    {
        _commandManager.RemoveHandler(CommandName);
        _commandManager.RemoveHandler(ShortCommandName);

        PluginInterface.UiBuilder.Draw -= DrawUI;
        PluginInterface.UiBuilder.OpenConfigUi -= DrawConfigUI;

        WindowSystem.RemoveAllWindows();
    }

    private void OnCommand(string command, string args) =>
        MainWindow.IsOpen = !MainWindow.IsOpen;

    private void DrawUI() => WindowSystem.Draw();
    private void DrawConfigUI() => MainWindow.IsOpen = true;
}