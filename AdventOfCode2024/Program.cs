// See https://aka.ms/new-console-template for more information

using AdventOfCode2024;
using AdventOfCode2024.Day2;


var reports = Day2.Reader(Day2Input.Part1);
var a = reports.Count(r => r.IsSafe);

Console.WriteLine(a);