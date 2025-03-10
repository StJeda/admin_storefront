namespace Jeda.Storefront.Infrastructure.Entities;

public record PartnerViewEntity
{
    public int PartnerId { get; init; }
    public required string FriendlyName { get; init; }
    public required string AccountNumber { get; init; }
    public decimal Balance { get; init; }
    public bool IsActive { get; init; }
}
