namespace AdventOfCode2024.Day_10;

public class GridNavigator
{
    public Tuple<int, int> StartingLocation { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public (int, int) Coords => (X, Y);
}