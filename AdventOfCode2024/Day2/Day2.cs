namespace AdventOfCode2024.Day2;

public static class Day2
{
    public static List<Report> Reader(string input)
    {
        var reports = new List<Report>();
        using var reader = new StringReader(input);
        while (reader.ReadLine() is { } line)
        {
            if (line.Length > 0)
            {
                reports.Add(new Report
                {
                    Levels = line.Split(" ").Select(int.Parse).ToList(),
                });
            }
        }

        return reports;
    }
}