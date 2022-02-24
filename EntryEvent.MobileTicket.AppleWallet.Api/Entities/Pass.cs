namespace EntryEvent.MobileTicket.AppleWallet.Api.Entities;

public record Pass
{
    public Guid Id { get; set; }
    public string? PassTypeId { get; set; }
    public string? SerialNumber { get; set; }
    public DateTime LastUpdated { get; set; }
}