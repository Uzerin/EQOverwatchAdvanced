namespace EQOverwatch.Core.Settings;

// The CH auto-press settings (EQ Overwatch Advanced).
public sealed partial class AppSettings
{
    /// <summary>Whether the auto-press was on when the app closed: it opens the same way.</summary>
    public bool AutoClickEnabled { get; set; }

    /// <summary>True: press every <see cref="AutoClickIntervalSeconds"/> after your own Complete Heal (chat ignored). False: on the chat cue.</summary>
    public bool AutoClickTimed { get; set; }

    /// <summary>Seconds between presses in timed mode (10.0 to 60.0).</summary>
    public double AutoClickIntervalSeconds { get; set; } = 10.0;

    /// <summary>The Complete Heal key the auto-press presses, like "2" or "Shift+F3".</summary>
    public string AutoClickKey { get; set; } = "2";

    /// <summary>
    /// The assist key, pressed 1.0 s and 0.5 s before the CH key while <see cref="AutoClickUseAssist"/> is on. Null in settings saved
    /// before 1.0.66.
    /// </summary>
    public string? AutoClickAssistKey { get; set; }

    /// <summary>
    /// Read from settings saved by 1.0.65 only (never written): true when its "Press key" mode was chosen. Otherwise its key was the
    /// unused default "1", and the CH key starts at 2 instead.
    /// </summary>
    public bool? AutoClickPressKey { get; set; }

    public bool AutoClickUseAssist { get; set; }

    /// <summary>The global hotkey that switches the auto-press on and off, such as "Ctrl+Alt+F9".</summary>
    public string AutoClickHotkey { get; set; } = "Ctrl+Alt+F9";
}
