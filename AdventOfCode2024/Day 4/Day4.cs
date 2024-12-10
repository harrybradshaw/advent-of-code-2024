using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day_4;

public static class Day4
{
    public static int Part1(string input)
    {
        const string word = "XMAS";
        var grid = new WordsearchGrid(input);
        var xmasCounter = 0;
        grid.FindWord(word, Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList(),  _ => xmasCounter++);
        Console.WriteLine(xmasCounter);
        return xmasCounter;
    }

    public static int Part2(string input)
    {
        const string word = "MAS";
        var grid = new WordsearchGrid(input);
        var locationOfAs = new Dictionary<(int, int), int>();
        
        grid.FindWord(word,
            [Direction.NorthEast, Direction.SouthEast, Direction.SouthWest, Direction.NorthWest],
            direction =>
            {
                var locationOfA = grid.PeekPreviousCoordinates(direction);
                if (!locationOfAs.TryAdd(locationOfA, 1))
                {
                    locationOfAs[locationOfA] += 1;
                }
            });

        var score = locationOfAs.Values.Count(v => v >= 2);
        Console.WriteLine(score);
        return score;
    }
}