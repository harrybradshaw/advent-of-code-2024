namespace AdventOfCode2024.Day2;

public class Report
{
    public required List<int> Levels { get; init; }
    public bool IsSafe => CalculateSafety(Levels, true);

    private static bool CalculateSafety(List<int> levels, bool shouldTryRemoving = false)
    {
        bool? isIncreasing = null;
        for (var i = 0; i < levels.Count - 1; i++)
        {
            var thisLevel = levels[i];
            var nextLevel = levels[i + 1];
            
            isIncreasing ??= nextLevel > thisLevel;
            
            var isConsistent = isIncreasing == (nextLevel > thisLevel);
            if (!isConsistent || Math.Abs(thisLevel - nextLevel) > 3 || thisLevel == nextLevel)
            {
                return shouldTryRemoving && RemoveElementsAndRetry(levels);
            }
        }

        return true;
    }

    private static bool RemoveElementsAndRetry(List<int> levels)
    {
        return levels.Select((_, i) =>
        {
            var newLevels = levels.Select(l => l).ToList();
            newLevels.RemoveAt(i);
            return CalculateSafety(newLevels);
        }).Any(b => b);
    }
}