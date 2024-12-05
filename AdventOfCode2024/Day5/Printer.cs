namespace AdventOfCode2024.Day5;

public class Printer
{
    private readonly List<PageUpdate> _pageUpdates;
    
    public Printer(string pageRules, string pageUpdates)
    {
        OrderingRules = new Dictionary<int, List<int>>();
        _pageUpdates = new List<PageUpdate>();

        ParseRules(pageRules);
        ParseUpdates(pageUpdates);
    }

    public void CalculateValidityOfPages()
    {
        foreach (var pageUpdate in _pageUpdates)
        {
            pageUpdate.CalculateValidity(OrderingRules);
        }
    }
    
    public List<PageUpdate> InvalidPages => _pageUpdates.Where(p => p.IsValid != true).ToList();
    public Dictionary<int, List<int>> OrderingRules { get; }

    public int CalculateScore()
    {
        return _pageUpdates.Where(pu => pu.IsValid == true).ToList().CalculateScore();
    }

    private void ParseRules(string pageRules)
    {
        using var reader = new StringReader(pageRules);
        while (reader.ReadLine() is { } line)
        {
            if (line.Length > 0)
            {
                var parts = line.Split("|").Select(int.Parse).ToArray();
                if (!OrderingRules.TryAdd(parts[0], [parts[1]]))
                {
                    OrderingRules[parts[0]].Add(parts[1]);
                }
            }
        }
    }

    private void ParseUpdates(string pageUpdates)
    {
        using var reader = new StringReader(pageUpdates);
        while (reader.ReadLine() is { } line)
        {
            if (line.Length > 0)
            {
                _pageUpdates.Add(new PageUpdate
                {
                    Pages = line.Split(",").Select(int.Parse).ToList()
                });
            }
        }
    }
}