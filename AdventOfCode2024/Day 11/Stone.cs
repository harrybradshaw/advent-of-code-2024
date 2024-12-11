namespace AdventOfCode2024.Day_11;

public class Stone
{
    public int StartingAge { get; set; }
    public long Value { get; set; }
    public string Key => $"s{StartingAge}v{Value}";
}