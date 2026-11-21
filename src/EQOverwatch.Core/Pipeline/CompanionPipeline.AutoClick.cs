using EQOverwatch.Core.Services;

namespace EQOverwatch.Core.Pipeline;

// The CH auto-press service (EQ Overwatch Advanced).
public sealed partial class CompanionPipeline
{
    /// <summary>Presses your CH key on your cleric's turn in the chain, while EverQuest is the window in front. Off until switched on.</summary>
    public AutoClickService AutoClick { get; private set; } = null!;

    partial void CreateEditionServices() => AutoClick = new AutoClickService(ChChain, Triggers);

    partial void DisposeEditionServices() => AutoClick.Dispose();
}
