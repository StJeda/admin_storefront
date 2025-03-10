namespace Jeda.Storefront.Infrastructure.Entities.Documents;

public record DocumentViewEntity
{
    public int DocumentId { get; init; }
    public decimal Amount { get; init; }
    public int ServiceId { get; init; }
    public DateTime Date { get; init; }
    public required string DocumentDetails { get; init; }
}
