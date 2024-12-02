// See https://aka.ms/new-console-template for more information

using AdventOfCode2024;

const string sampleInput = """
                           3   4
                           4   3
                           2   5
                           1   3
                           3   9
                           3   3
                           """;

Tuple<List<int>, List<int>> Reader(string input)
{
    var list1 = new List<int>();
    var list2 = new List<int>();

    using (System.IO.StringReader reader = new System.IO.StringReader(input))
    {
        while (reader.ReadLine() is { } line)
        {
            var x = line.Split("  ");
            if (x.Length == 2)
            {
                list1.Add(int.Parse(x[0]));
                list2.Add(int.Parse(x[1]));
            }
        }
    }

    return new Tuple<List<int>, List<int>>(list1, list2);
}

int SolvePart1(Tuple<List<int>, List<int>> parsedInput)
{
    parsedInput.Item1.Sort();
    parsedInput.Item2.Sort();

    var zipped = parsedInput.Item1.Zip(parsedInput.Item2);
    return zipped.Aggregate(0, (sum, next) => sum + Math.Abs(next.First - next.Second));
}

int SolvePart2(Tuple<List<int>, List<int>> parsedInput)
{
    var secondHalfDict = new Dictionary<int, int>();
    foreach (var secondNumber in parsedInput.Item2)
    {
        if (!secondHalfDict.TryAdd(secondNumber, 1))
        {
            secondHalfDict[secondNumber] += 1;
        }
    }

    return parsedInput.Item1.Aggregate(0, (sum, next) =>
    {
        var value = next * secondHalfDict.GetValueOrDefault(next, 0);
        return sum + value;
    });
}

var x = Reader(Input.Day1);
var a = SolvePart2(x);
Console.WriteLine(a);