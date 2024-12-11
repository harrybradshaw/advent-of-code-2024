namespace AdventOfCode2024.Day_11;

public class Day11
{
    private readonly Dictionary<long, (long, long?)> _calculationDictionary = new Dictionary<long, (long, long?)>();
    
    public long Part1(string input)
    {
        var ans = Run(input, 25);
        Console.WriteLine(ans);
        return ans;
    }
    
    public long Part2(string input)
    {
        var ans = Run(input, 75);
        Console.WriteLine(ans);
        return ans;
    }

    private long Run(string input, int maxAge)
    {
        long one = 1;
        var counts = input.Split(' ')
            .Select(long.Parse)
            .ToDictionary(s => s, s => one);
        
        for (int a = 0; a < maxAge; a++)
        {
            var d = new Dictionary<long, long>();
            foreach (var key in counts.Keys)
            {
                var (updatedValue, newStoneValue) = ProcessSingle(key);
                if (!d.TryAdd(updatedValue, counts[key]))
                {
                    d[updatedValue] += counts[key];
                }

                if (newStoneValue.HasValue && !d.TryAdd(newStoneValue.Value, counts[key]))
                {
                    d[newStoneValue.Value] += counts[key];
                }
            }

            counts = d;
        }

        long start = 0;
        var ans = counts.Values.Aggregate(start, (i, i1) => i + i1);
        return ans;
    }

    private (long, long?) ProcessSingle(long start)
    {
        if (_calculationDictionary.TryGetValue(start, out var value))
        {
            return value;
        }
        
        if (start == 0)
        {
            _calculationDictionary.Add(start, (1, null));
            return (1, null);
        }
        if ((int)Math.Floor(Math.Log10(start) + 1) % 2 == 0)
        {
            var val = (GetFirstHalf(start), GetSecondHalf(start));
            _calculationDictionary.Add(start, val);
            return val;
        }
        else
        {
            var val = start * 2024;
            _calculationDictionary.Add(start, (val, null));
            return (val, null);
        }
    }
    
    
    private static long GetFirstHalf(long originalLong)
    {
        int totalDigits = (int)Math.Floor(Math.Log10(originalLong) + 1);
        int digitsToRemove = totalDigits / 2;
        long divisor = (long)Math.Pow(10, digitsToRemove);

        return originalLong / divisor;
    }
    
    private static long GetSecondHalf(long originalLong)
    {
        int totalDigits = (int)Math.Floor(Math.Log10(originalLong) + 1);
        int digitsToKeep = totalDigits / 2;
        long divisor = (long)Math.Pow(10, digitsToKeep);

        return originalLong % divisor;
    }
}