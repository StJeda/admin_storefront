namespace Jeda.Storefront.Infrastructure.Entities.Documents;

public record DocumentLineViewEntity
{
    public Guid DocumentLineId { get; init; }
    public int DocumentId { get; init; }
    public required string Key { get; init; }
    public required string Value { get; init; }
}