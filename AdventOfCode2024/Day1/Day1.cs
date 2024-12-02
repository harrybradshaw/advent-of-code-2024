namespace AdventOfCode2024.Day1;

public static class Day1
{
    public static Tuple<List<int>, List<int>> Reader(string input)
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

    public static int SolvePart1(Tuple<List<int>, List<int>> parsedInput)
    {
        parsedInput.Item1.Sort();
        parsedInput.Item2.Sort();

        var zipped = parsedInput.Item1.Zip(parsedInput.Item2);
        return zipped.Aggregate(0, (sum, next) => sum + Math.Abs(next.First - next.Second));
    }

    public static int SolvePart2(Tuple<List<int>, List<int>> parsedInput)
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

}