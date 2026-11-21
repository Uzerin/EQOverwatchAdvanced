using EQOverwatch.App.Services;
using EQOverwatch.Core.Settings;

namespace EQOverwatch.App.Tests;

public partial class MainViewModelTests
{
    private sealed partial class FakeOverlayHost
    {
        /// <summary>The overlay with the red auto-press outline, or null.</summary>
        public OverlayKind? Outline { get; private set; }

        public void SetArmedOutline(OverlayKind? kind) => Outline = kind;
    }
}
