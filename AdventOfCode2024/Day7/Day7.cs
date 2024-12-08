namespace AdventOfCode2024.Day7;

public class Day7
{
    private Queue<(long, List<long>)> calcs;
    private bool couldComplete;

    public void Part1(string input)
    {
        Run(input, ['+', '*']);
    }
    
    public void Part2(string input)
    {
        Run(input, ['+', '*', '|']);
    }

    private void Run(string input, List<char> operators)
    {
        long sum = 0;
        using var reader = new StringReader(input);
        while (reader.ReadLine() is { } line)
        {
            calcs = new Queue<(long, List<long>)>();
            couldComplete = false;
            var parts = line.Split(": ");
            var target = long.Parse(parts[0]);
            var numbers = parts[1].Split(" ").Select(long.Parse).ToList();
            calcs.Enqueue((target, numbers));
            while (calcs.Count != 0 && !couldComplete)
            {
                ProcessOnce(operators);
            }

            if (couldComplete)
            {
                sum += target;
            }
        }
        Console.WriteLine(sum);
    }

    private void ProcessOnce(List<char> operators)
    {
        var (target, numsToUse) = calcs.Dequeue();
        if (numsToUse.Count == 1)
        {
            couldComplete = numsToUse.First() == target;
            return;
        }

        var lastNum = numsToUse.Last();
        foreach (var op in operators)
        {
            if (op == '+')
            {
                var newTarget = target - lastNum;
                if (newTarget > 0)
                {
                    calcs.Enqueue((newTarget, numsToUse.SkipLast(1).ToList()));
                }
            }

            if (op == '*')
            {
                var remainder = target % lastNum;
                var newTarget = target / lastNum;

                if (remainder == 0 && newTarget >= 1)
                {
                    calcs.Enqueue((newTarget, numsToUse.SkipLast(1).ToList()));
                }
            }

            if (op == '|')
            {
                var stringTarget = target.ToString();
                var lastNumAsString = lastNum.ToString();
                var lastNCharsAsString = new string(stringTarget.ToCharArray().TakeLast(lastNumAsString.Length).ToArray());
                var newTargetAsString = stringTarget.SkipLast(lastNumAsString.Length).ToArray();
                if (lastNCharsAsString == lastNumAsString && newTargetAsString.Length > 0)
                {
                    var newTarget = long.Parse(new string(newTargetAsString));
                    calcs.Enqueue((newTarget, numsToUse.SkipLast(1).ToList()));
                }
            }
        }
    }
}