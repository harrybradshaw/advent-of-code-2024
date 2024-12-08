namespace AdventOfCode2024.Day8;

public class Location
{
    public char Frequency { get; set; }
    public int x { get; set; }
    public int y { get; set; }

    public bool IsWithinBounds((int, int) difference, int multi, int xMax, int yMax)
    {
        return x + multi * difference.Item1 < xMax
            && y + multi * difference.Item2 < yMax
            && x + multi * difference.Item1 >= 0
            && y + multi * difference.Item2 >= 0;
    }
}