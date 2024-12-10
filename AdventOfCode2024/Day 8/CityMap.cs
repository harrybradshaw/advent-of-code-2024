using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day_8;

public class CityMap : Grid
{
    private readonly List<Location> _radioLocations;
    
    public CityMap(string input) : base(input)
    {
        _radioLocations = _locationDictionary.Keys
            .Where(c => c != '.' && c != '#')
            .SelectMany(c => _locationDictionary[c].Select(l => new Location
                {
                    Frequency = c,
                    x = l.Item1,
                    y = l.Item2,
                }))
            .ToList();
    }

    public int FindAntinodes(bool specificDistance = true)
    {
        var antinodes = new List<Location>();
        foreach (var location in _radioLocations)
        {
            var allLocations = _locationDictionary[location.Frequency];
            foreach (var pairedLocation in allLocations)
            {
                if (location.x != pairedLocation.Item1 && location.y != pairedLocation.Item2)
                {
                    var difference = (location.x - pairedLocation.Item1, location.y - pairedLocation.Item2);

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
        return distinctLocations.Count;
    }
}