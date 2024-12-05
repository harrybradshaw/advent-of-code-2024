namespace AdventOfCode2024.Day5;

public static class PageUpdateExt
{
    public static int CalculateScore(this List<PageUpdate> pageUpdates)
    {
        return pageUpdates.Aggregate(0, (sum, next) => sum + next.MiddleNumber);
    }
}

public class PageUpdate
{
    public required List<int> Pages { get; set; }
    public bool? IsValid { get; set; }
    public int MiddleNumber => Pages[((Pages.Count - 1) / 2)];

    public void CalculateValidity(Dictionary<int, List<int>> orderingRules)
    {
        var pagesSeen = new HashSet<int>();
        foreach (var pageNumber in Pages)
        {
            var pagesThatMustBeAfter = orderingRules.GetValueOrDefault(pageNumber);
            if (pagesThatMustBeAfter != null && pagesThatMustBeAfter.Any(p => pagesSeen.Contains(p)))
            {
                IsValid = false;
                return;
            }
            pagesSeen.Add(pageNumber);
        }
        IsValid = true;
    }

    public void Sort(Dictionary<int, List<int>> orderingRules)
    {
        Pages.Sort((x, y) =>
        {
            var rulesForX = orderingRules.GetValueOrDefault(x);
            var rulesForY = orderingRules.GetValueOrDefault(y);
            if (rulesForX == null && rulesForY == null)
            {
                return 0;
            }

            if (rulesForX != null && rulesForX.Contains(y))
            {
                return -1;
            }

            if (rulesForY != null && rulesForY.Contains(x))
            {
                return 1;
            }

            return 0;
        });
    }
}