namespace Jeda.Storefront.Infrastructure.Entities.Financial;

public record FinancialEntryViewEntity
{
    public long EntryId { get; init; }
    public required string AccountFrom { get; init; }
    public required string AccountTo { get; init; }
    public decimal Debit { get; init; }
    public decimal Credit { get; init; }
    public required string Description { get; init; }
    public DateTime Date { get; init; } = DateTime.Now; 
}
