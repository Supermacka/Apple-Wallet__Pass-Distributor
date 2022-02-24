using AppleWallet.Api.Repositories;
using AppleWallet.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using AppleWallet.Library;


namespace AppleWallet.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PassesController : ControllerBase
{
    private readonly IRegistrations _registrations;

    public PassesController(IRegistrations registrations)
    {
        this._registrations = registrations;
    }
    
    [Route("{passType}")]
    [HttpGet]
    public FileContentResult Get(string passType)
    {
        return new FileContentResult(_registrations.CreatePass(passType), "application/vnd.apple.pkpass");
    }
    
    // [Route("{version}/devices/{deviceLibraryId}/registrations/{passTypeId}/{serialNumber}")]
    // [HttpPost]
    // public ActionResult<Pass> Update(string deviceLibraryId, string passTypeId, string serialNumber)
    // {
    //     /* TODO:
    //      * Payload:
    //      *      The POST payload is a JSON dictionary containing a single key and value:
    //      *      pushToken - The push token that the server can use to send push notifications to this device.
    //      */
    //     
    //     // TODO: Authenticate pass request
    //     /*
    //      * If the serial number is already registered for this device, returns HTTP status 200.
    //      * If registration succeeds, returns HTTP status 201.
    //      * If the request is not authorized, returns HTTP status 401.
    //      * Otherwise, returns the appropriate standard HTTP status.
    //      */
    //
    //     var pass = _registrations.GetPass(passTypeId, serialNumber);
    //     if (pass is null)
    //     {
    //         return NotFound();
    //     }
    //
    //     return Ok(pass);
    // }
    
    // TODO: Create endpoint for pass delete
}