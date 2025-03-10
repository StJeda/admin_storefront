namespace Jeda.Storefront.Infrastructure.Entities;

public class TradePointViewEntity
{
    public int TradePointId { get; init; }
    public required string Name { get; init; }
    public string? Description { get; init; }
    public required string Address { get; init; }
    public required bool UseCommission { get; init; }
    public float? Commission { get; init; }
    public required string OpeningHours { get; init; }
}