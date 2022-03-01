namespace AppleWallet.Library;

public interface IOneTimeUsePass
{
    public byte[] Create(string companyName, ImagePaths imagePaths, PassFieldData passFieldData);
}