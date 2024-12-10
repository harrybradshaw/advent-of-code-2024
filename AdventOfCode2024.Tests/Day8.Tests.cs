using AdventOfCode2024.Day_8;
using FluentAssertions;

namespace AdventOfCode2024.Tests;

public class Day8_Tests
{
    [TestCase(Day8Input.Sample, 14)]
    public void Part1(string input, int expectedScore)
    {
        var score = Day8.Part1(input);
        score.Should().Be(expectedScore);
    }
    
    [TestCase(Day8Input.Sample, 34)]
    public void Part2(string input, int expectedScore)
    {
        var score = Day8.Part2(input);
        score.Should().Be(expectedScore);
    }   
}