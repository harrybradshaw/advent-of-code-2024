namespace AdventOfCode2024.Day_8;

public static class Day8
{
    public static int Part1(string input)
    {
        var map = new CityMap(input);
        return map.FindAntinodes();
    }
    
    public static int Part2(string input)
    {
        var map = new CityMap(input);
        return map.FindAntinodes(specificDistance: false);
    }
}