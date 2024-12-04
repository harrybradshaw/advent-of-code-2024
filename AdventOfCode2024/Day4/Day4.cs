namespace AdventOfCode2024.Day4;

public static class Day4
{
    public static void Part1()
    {
        const string word = "XMAS";
        var grid = new Grid(Day4Input.Puzzle);
        var xmasCounter = 0;
        grid.FindWord(word, Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList(), (grid1, direction) => xmasCounter++);
        Console.WriteLine(xmasCounter);
    }

    public static void Part2()
    {
        const string word = "MAS";
        var grid = new Grid(Day4Input.Puzzle);
        var locationOfAs = new Dictionary<(int, int), int>();
        
        grid.FindWord(word,
            [Direction.NorthEast, Direction.SouthEast, Direction.SouthWest, Direction.NorthWest],
            ((grid1, direction) =>
            {
                var locationOfA = grid1.GetPrevious(direction);
                if (!locationOfAs.TryAdd(locationOfA, 1))
                {
                    locationOfAs[locationOfA] += 1;
                }
            }));
        
        Console.WriteLine(locationOfAs.Values.Count(v => v >= 2));
    }
}