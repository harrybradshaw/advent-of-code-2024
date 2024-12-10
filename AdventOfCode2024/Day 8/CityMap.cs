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
        var antinodeLocations = new HashSet<(int, int)>();
        foreach (var location in _radioLocations)
        {
            var allLocations = _locationDictionary[location.Frequency];
            foreach (var pairedLocation in allLocations)
            {
                if (location.x != pairedLocation.Item1 && location.y != pairedLocation.Item2)
                {
                    var difference = (location.x - pairedLocation.Item1, location.y - pairedLocation.Item2);

                    var multi = specificDistance ? 1 : 0;
                    while (IsWithinBounds(GenerateNewCoords(location, difference, multi))
                           && (!specificDistance || multi <= 1))
                    {
                        antinodeLocations.Add(GenerateNewCoords(location, difference, multi));
                        multi++;
                    }
                    
                    multi = specificDistance ? -2 : -1;
                    while (IsWithinBounds(GenerateNewCoords(location, difference, multi))
                           && (!specificDistance || multi >= -2))
                    {
                        antinodeLocations.Add(GenerateNewCoords(location, difference, multi));
                        multi--;
                    }
                }
            }
        }

        Console.WriteLine(antinodeLocations.Count);
        return antinodeLocations.Count;
    }

    private static (int, int) GenerateNewCoords(Location location, (int, int) difference, int multi)
    {
        return (location.x + multi * difference.Item1, location.y + multi * difference.Item2);
    }
}