using AppleWallet.Api.Entities;

namespace AppleWallet.Api.Repositories;

public interface IRegistrations
{
    public byte[] CreatePass(string passType); // TODO: pathToLogotype, companyName, tickets
    public Pass? GetPass(string passTypeId, string serialNumber);
}