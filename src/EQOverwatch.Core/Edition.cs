namespace EQOverwatch.Core;

/// <summary>
/// The values that set this build apart from other editions made from the same code (EQ Overwatch keeps its own copy of this file):
/// the name, the repository its updates come from and its settings folder.
/// </summary>
public static class Edition
{
    public const string Name = "EQ Overwatch Advanced";

    /// <summary>The public GitHub repository this edition's releases are published to ("owner/name").</summary>
    public const string Repository = "Uzerin/EQOverwatchAdvanced";

    /// <summary>Folder under <c>%LocalAppData%</c> that holds this edition's settings and data.</summary>
    public const string SettingsFolderName = "EQOverwatchAdvanced";

    /// <summary>Another edition's folder under <c>%LocalAppData%</c> copied on first start when this edition has none yet, or null.</summary>
    public static string? ImportFolderName => "EQOverwatch";
}
