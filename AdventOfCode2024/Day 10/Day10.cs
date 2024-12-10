using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day_10;

public static class Day10
{
    public static int Part1(string input)
    {
        var finishingGridNavigators = Run(input);
        var l = finishingGridNavigators.ToLookup(d => d.Coords);
        var score = l.Aggregate(0, (i, gridNavigatorsForFinishingLocation) => i + gridNavigatorsForFinishingLocation.DistinctBy(d => d.StartingLocation).Count());
        return score;
    }

    public static int Part2(string input)
    {
        var finishingGridNavigators = Run(input);
        var score = finishingGridNavigators.Count;
        Console.WriteLine(score);
        return score;
    }

    private static List<GridNavigator> Run(string input)
    {
        var grid = new Grid(input);
        var startingLocations = grid.GetLocations('0');
        var queue = new Queue<GridNavigator>();
        var directionsToSearch = new List<Direction>
        {
            Direction.North,
            Direction.East,
            Direction.South,
            Direction.West,
        };
        foreach (var startingLocation in startingLocations)
        {
            queue.Enqueue(new GridNavigator
            {
                StartingLocation = startingLocation,
                X = startingLocation.Item1,
                Y = startingLocation.Item2,
            });
        }

        var finishingGridNavigators = new List<GridNavigator>();
        while (queue.Count > 0)
        {
            var item = queue.Dequeue();
            var valueChar = grid.GetElementAndSetRef(item.X, item.Y);
            var value = int.Parse(valueChar!.Value.ToString());
            foreach (var direction in directionsToSearch)
            {
                var inDirection = grid.PeekNextElement(direction);
                if (inDirection.HasValue
                    && int.TryParse(inDirection.ToString(), out var inDirectionInt)
                    && inDirectionInt - value == 1)
                {
                    var newCor = grid.PeekNextCoordinates(direction);
                    var newGridNav = new GridNavigator
                    {
                        StartingLocation = item.StartingLocation,
                        X = newCor.Item1,
                        Y = newCor.Item2,
                    };
                    if (inDirectionInt == 9)
                    {
                        finishingGridNavigators.Add(newGridNav);
                    }
                    else
                    {
                        queue.Enqueue(newGridNav);
                    }
                }
            }
        }

        return finishingGridNavigators;
    }
}