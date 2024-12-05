using AdventOfCode2024.Day4;

namespace AdventOfCode2024.Day5;

public static class Day5
{
    public static void Part1()
    {
        var printer = new Printer(Day5Input.PuzzleOrderingRules, Day5Input.PuzzlePageUpdates);
        printer.CalculateValidityOfPages();
        Console.WriteLine(printer.CalculateScore());
    }

    public static void Part2()
    {
        var printer = new Printer(Day5Input.PuzzleOrderingRules, Day5Input.PuzzlePageUpdates);
        printer.CalculateValidityOfPages();

        var pages = printer.InvalidPages;
        foreach (var page in pages)
        {
            page.Sort(printer.OrderingRules);
        }
        
        Console.WriteLine(pages.CalculateScore());
    }
}