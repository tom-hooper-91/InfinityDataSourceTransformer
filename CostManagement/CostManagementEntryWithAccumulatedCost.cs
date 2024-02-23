namespace CostManagement;

public record CostManagementEntryWithAccumulatedCost
{
    public int Date { get; init; }
    public double Cost { get; init; }
    public double AccumulatedCost { get; init; }
}