using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day_6;

public class Day6
{
    public static int Part1(string input)
    {
        var grid = new Grid(input);
        var (uniquePositions, _) = Run(grid);
        Console.WriteLine(uniquePositions.Count);
        return uniquePositions.Count;
    }

    public static int Part2(string input)
    {
        var grid = new Grid(input);
        var (uniquePositions, _) = Run(grid);
        var counter = 0;

        foreach (var pos in uniquePositions)
        {
            var (x, y) = pos;
            var startingChar = grid.GetElement(x, y);
            if (startingChar != '#' && startingChar != '^')
            {
                grid.PlaceCharAtPosition(x, y, '#');
                var (_, managedToExit) = Run(grid);
                if (!managedToExit)
                {
                    counter += 1;
                }
                grid.PlaceCharAtPosition(x, y, startingChar);
            }
        }
        Console.WriteLine(counter);
        return counter;
    }

    private static (HashSet<Tuple<int, int>>, bool) Run(Grid grid)
    {
        var managedToExit = false;
        grid.SetRefOnSingleChar('^');

        var startingPosition = grid.GetPosition();
        var currentDirection = Direction.North;

        var positionsWithDirection = new HashSet<Tuple<int, int, Direction>>
        {
            new(startingPosition.Item1, startingPosition.Item2, currentDirection)
        };
        var positions = new HashSet<Tuple<int, int>>
        {
            startingPosition,
        };

        while (true)
        {
            var newChar = grid.Traverse(currentDirection, '#');
            var position = grid.GetPosition();
            if (newChar == '#')
            {
                currentDirection = DirectionHelper.Rot90(currentDirection);
            }
            else if (newChar == null)
            {
                managedToExit = true;
                break;
            }
            else
            {
                positions.Add(position);
                if (!positionsWithDirection.Add(new Tuple<int, int, Direction>(position.Item1, position.Item2,  currentDirection)))
                {
                    break;
                }
            }
        }

        return (positions, managedToExit);
    }
}