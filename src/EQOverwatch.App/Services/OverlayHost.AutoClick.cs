using EQOverwatch.App.Overlays;
using EQOverwatch.Core.Settings;

namespace EQOverwatch.App.Services;

// The red outline round an overlay while the CH auto-press is on (EQ Overwatch Advanced).
public partial interface IOverlayHost
{
    /// <summary>Puts the red "auto-press is on" outline round one overlay, or takes it away (null).</summary>
    void SetArmedOutline(OverlayKind? kind)
    {
    }
}

public sealed partial class OverlayHost
{
    private ArmedOutlineWindow? _outline;

    public void SetArmedOutline(OverlayKind? kind)
    {
        if (kind is null && _outline is null)
        {
            return;
        }

        _outline ??= new ArmedOutlineWindow();
        _outline.Follow(kind is { } k ? Get(k) : null);
    }

    partial void CloseEditionWindows()
    {
        try
        {
            _outline?.Close();
        }
        catch (InvalidOperationException)
        {
            // already closed
        }
    }
}
