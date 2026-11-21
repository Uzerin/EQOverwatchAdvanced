using System.Windows;
using EQOverwatch.App.Interop;

namespace EQOverwatch.App;

// The CH auto-press window and its global hotkey (EQ Overwatch Advanced).
public partial class MainWindow
{
    private AutoClickWindow? _autoClickWindow;
    private GlobalHotkey? _hotkey;

    partial void OnEditionCreated() => _viewModel.ShowAutoClickRequested += OpenAutoClickWindow;

    partial void OnEditionSourceInitialized()
    {
        // The hotkey that switches the CH auto-press on and off works from any program.
        _hotkey = new GlobalHotkey(this, id: 0x4551);
        _hotkey.Pressed += _viewModel.ToggleAutoClick;
        _viewModel.AutoClickHotkeyChanged += RegisterAutoClickHotkey;
        RegisterAutoClickHotkey();
    }

    partial void OnEditionClosing()
    {
        _viewModel.AutoClickHotkeyChanged -= RegisterAutoClickHotkey;
        _hotkey?.Dispose();
    }

    private void OpenAutoClickWindow()
    {
        if (_autoClickWindow is null)
        {
            _autoClickWindow = new AutoClickWindow(_viewModel) { Owner = this };
            _autoClickWindow.Closed += (_, _) => _autoClickWindow = null;
            _autoClickWindow.Show();
        }
        else
        {
            if (_autoClickWindow.WindowState == WindowState.Minimized)
            {
                _autoClickWindow.WindowState = WindowState.Normal;
            }

            _autoClickWindow.Activate();
        }
    }

    private void RegisterAutoClickHotkey()
    {
        if (_hotkey is null)
        {
            return;
        }

        bool ok = HotkeyParser.TryParse(_viewModel.AutoClickHotkey, out uint modifiers, out uint key) && _hotkey.Register(modifiers, key);
        if (!ok)
        {
            _hotkey.Unregister();
        }

        _viewModel.ReportAutoClickHotkey(ok);
    }
}
