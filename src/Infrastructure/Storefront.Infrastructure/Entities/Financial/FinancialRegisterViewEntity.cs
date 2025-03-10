namespace Jeda.Storefront.Infrastructure.Entities.Financial;

public record FinancialRegisterViewEntity
{
    public long RegisterId { get; init; }
    public required string AccountFrom { get; init; }
    public required string AccountTo { get; init; }
    public decimal Amount { get; init; }
    public DateTime Date { get; init; }
    public required string Description { get; init; }

}