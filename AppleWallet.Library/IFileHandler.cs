using Microsoft.AspNetCore.Mvc;

namespace AppleWallet.Library;

public interface IFileHandler
{
    public FileContentResult GetFile(List<byte[]> pass);
}