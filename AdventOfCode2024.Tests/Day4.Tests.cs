using AdventOfCode2024.Day_4;
using FluentAssertions;

namespace AdventOfCode2024.Tests;

public class Day4_Tests
{
    [TestCase(Day4Input.Sample, 18)]
    public void Part1(string input, int expectedScore)
    {
        var score = Day4.Part1(input);
        score.Should().Be(expectedScore);
    }
    
    [TestCase(Day4Input.Sample, 9)]
    public void Part2(string input, int expectedScore)
    {
        var score = Day4.Part2(input);
        score.Should().Be(expectedScore);
    }
}