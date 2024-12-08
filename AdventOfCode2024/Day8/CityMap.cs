namespace AdventOfCode2024.Day8;

public class CityMap
{
    private readonly int _xMax = 0;
    private readonly int _yMax = 0;

    private readonly List<Location> _radioLocations;
    private readonly ILookup<char, Location> _radioLocationLookup;
    
    public CityMap(string input)
    {
        List<List<char>> grid = [];
        using var reader = new StringReader(input);
        while (reader.ReadLine() is { } line)
        {
            if (line.Length > 0)
            {
                grid.Add(line.ToCharArray().ToList());
                _xMax = line.Length;
            }
            _yMax++;
        }

        _radioLocations = new List<Location>();
        for (var y = 0; y < _yMax; y++)
        {
            for (var x = 0; x < _xMax; x++)
            {
                var location = grid[y][x];
                if (location != '.' && location != '#')
                {
                    _radioLocations.Add(new Location
                    {
                        Frequency = location,
                        x = x,
                        y = y,
                    });
                }
               
            }
        }

        _radioLocationLookup = _radioLocations.ToLookup(r => r.Frequency);
    }

    public void FindAntinodes(bool specificDistance = true)
    {
        var antinodes = new List<Location>();
        foreach (var location in _radioLocations)
        {
            var allLocations = _radioLocationLookup[location.Frequency];
            foreach (var pairedLocation in allLocations)
            {
                if (location != pairedLocation)
                {
                    var difference = (location.x - pairedLocation.x, location.y - pairedLocation.y);

                    var multi = specificDistance ? 1 : 0;
                    while (location.IsWithinBounds(difference, multi, _xMax, _xMax)
                           && (!specificDistance || multi <= 1))
                    {
                        var newLocation = new Location
                        {
                            Frequency = '#',
                            x = location.x + multi * difference.Item1,
                            y = location.y + multi * difference.Item2,
                        };
                        antinodes.Add(newLocation);
                        multi++;
                    }
                    
                    multi = specificDistance ? -2 : -1;
                    while (location.IsWithinBounds(difference, multi, _xMax, _xMax)
                           && (!specificDistance || multi >= -2))
                    {
                        var newLocation = new Location
                        {
                            Frequency = '#',
                            x = location.x + multi * difference.Item1,
                            y = location.y + multi * difference.Item2,
                        };
                        antinodes.Add(newLocation);
                        multi--;
                    }
                }
            }
        }

        var distinctLocations = antinodes.DistinctBy(h => (h.x, h.y)).ToList();
        Console.WriteLine(distinctLocations.Count);
    }
}