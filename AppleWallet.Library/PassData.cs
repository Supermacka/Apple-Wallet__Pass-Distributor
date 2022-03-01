namespace AppleWallet.Library;

/// <summary>
/// Represents the overall data to create a pass
/// </summary>
public class PassData
{
    public ImagePaths ImagePaths { get; set; }
    public PassFieldData[] PassFieldData { get; set; }
}