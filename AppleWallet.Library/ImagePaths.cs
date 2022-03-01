namespace AppleWallet.Library;

/// <summary>
/// Represents the specified paths for images that are displayed in the pass.
/// </summary>
public record ImagePaths
{
    public string? IconPath { get; set; }
    public string? LogoPath { get; set; }
    public string? StripPath { get; set; }
    public string? BackgroundPath { get; set; }
    public string? ThumbnailPath { get; set; }
    public string? FooterPath { get; set; } // NOTE: Only supported with type: Boarding-pass
}