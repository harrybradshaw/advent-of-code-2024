using AdventOfCode2024.Day_6;
using FluentAssertions;

namespace AdventOfCode2024.Tests;

public class Day6_Tests
{
    [TestCase(Day6Input.Sample, 41)]
    public void Part1(string input, int expectedScore)
    {
        var score = Day6.Part1(input);
        score.Should().Be(expectedScore);
    }
    
    [TestCase(Day6Input.Sample, 6)]
    public void Part2(string input, int expectedScore)
    {
        var score = Day6.Part2(input);
        score.Should().Be(expectedScore);
    }   
}