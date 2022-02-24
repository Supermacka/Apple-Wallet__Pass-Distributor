using EntryEvent.MobileTicket.AppleWallet.Api.Entities;
using EntryEvent.MobileTicket.AppleWallet.Library;

namespace EntryEvent.MobileTicket.AppleWallet.Api.Repositories;

public class Registrations : IRegistrations
{
    private readonly List<Device> _devices = new() { };
    private readonly List<Pass> _passes = new() { };
    
    // TODO: Function for adding new passes
    // Will have to create  
    public byte[] CreatePass(string passType)
    {
        var serialNumber = Guid.NewGuid().ToString();

        _passes.Add(new Pass()
        {
            Id = Guid.NewGuid(),
            PassTypeId = TopLevelKeys.PassTypeIdentifier,
            SerialNumber = serialNumber,
            LastUpdated = DateTime.Now,
        });

        return TosselillaPass.Create(serialNumber);
    }

    public Pass? GetPass(string passTypeId, string serialNumber)
    {
        return _passes.Where((p) => p.PassTypeId == passTypeId && p.SerialNumber == serialNumber).FirstOrDefault();
    }
    
}