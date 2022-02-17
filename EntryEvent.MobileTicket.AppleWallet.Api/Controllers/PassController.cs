using Microsoft.AspNetCore.Mvc;
using EntryEvent.MobileTicket.AppleWallet.Library;


namespace EntryEvent.MobileTicket.AppleWallet.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PassController : ControllerBase
{
    [HttpGet(Name = "GetPkPassFile")]
    public FileContentResult Get()
    {
        return new FileContentResult(TosselillaPass.Create(), "application/vnd.apple.pkpass");
    }
}