using System.Data;
using System.Globalization;
using System.Text.Json;

namespace CostManagement
{
    public static class CostManagementTransformer
    {
        private static List<CostManagementEntry> ParseCostManagementEntries(string jsonString)
        {
            var costManagementRaw = JsonSerializer.Deserialize<CostManagementRaw>(jsonString);

            return costManagementRaw!.Row.Select(row => new CostManagementEntry { Cost = Convert.ToDouble(row[0]), Date = Convert.ToInt32(row[1]) }).ToList();
        }

        public static List<CostManagementEntryWithAccumulatedCost> GenerateListOfEntriesWithAccumulatedCost(string jsonString)
        {
            var entries = ParseCostManagementEntries(jsonString);
            var accumulatedCostList = new List<CostManagementEntryWithAccumulatedCost>();
            double accumulatedCost = 0;

            foreach (var entry in entries)
            {
                accumulatedCost += entry.Cost;
                accumulatedCostList.Add(new CostManagementEntryWithAccumulatedCost
                {
                    AccumulatedCost = accumulatedCost,
                    Cost = entry.Cost,
                    Date = entry.Date
                });
            }

            return accumulatedCostList;
        }
    }
}
