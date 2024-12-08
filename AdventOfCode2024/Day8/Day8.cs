namespace AdventOfCode2024.Day8;

public static class Day8
{
    public static void Part1()
    {
        var map = new CityMap(Day8Input.Puzzle);
        map.FindAntinodes();
    }
    
    public static void Part2()
    {
        var map = new CityMap(Day8Input.Puzzle);
        map.FindAntinodes(specificDistance: false);
    }
}