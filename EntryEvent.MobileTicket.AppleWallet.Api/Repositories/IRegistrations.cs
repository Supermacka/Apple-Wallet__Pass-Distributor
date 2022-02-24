using EntryEvent.MobileTicket.AppleWallet.Api.Entities;

namespace EntryEvent.MobileTicket.AppleWallet.Api.Repositories;

public interface IRegistrations
{
    public byte[] CreatePass(string passType);
    public Pass? GetPass(string passTypeId, string serialNumber);
}