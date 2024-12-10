namespace AdventOfCode2024.Helpers;

public static class DirectionHelper
{
    public static Direction Rot90(Direction direction)
    {
        return direction switch
        {
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            Direction.West => Direction.North,
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
}