namespace CostManagement;

internal record CostManagementEntry
{
    public int Date { get; init; }
    public double Cost { get; init; }
}