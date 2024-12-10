using AdventOfCode2024.Day_10;
using FluentAssertions;

namespace AdventOfCode2024.Tests;

public class Day10_Tests
{
    [TestCase(Day10Input.SampleTwo, 36)]
    public void Part1(string input, int expectedScore)
    {
        var score = Day10.Part1(input);
        score.Should().Be(expectedScore);
    }
    
    [TestCase(Day10Input.SampleTwo, 81)]
    public void Part2(string input, int expectedScore)
    {
        var score = Day10.Part2(Day10Input.SampleTwo);
        score.Should().Be(expectedScore);
    }
}