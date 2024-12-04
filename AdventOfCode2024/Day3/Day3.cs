namespace AdventOfCode2024.Day3;

public class Day3
{
    public static void Run(string input)
    {
        var total = 0;
        var enabled = true;
        for (var i = 0; i < input.Length - 8; i++)
        {
            var testPhrase = input[i..];
            if (testPhrase.StartsWith("do()"))
            {
                enabled = true;
            } else if (testPhrase.StartsWith("don't()"))
            {
                enabled = false;
            } else if (testPhrase.StartsWith("mul("))
            {
                var j = 4; // Index within substring of first non-integer, after mul(.
                while (int.TryParse(testPhrase[j].ToString(), out _))
                {
                    j++;
                    if (j + i >= input.Length - 2)
                    {
                        return;
                    }
                }

                if (j != 4 && testPhrase[j].ToString() == ",")
                {
                    var k = j + 1;
                    while (int.TryParse(testPhrase[k].ToString(), out _))
                    {
                        k++;
                        if (k + i >= input.Length)
                        {
                            return;
                        }
                    }

                    if (k != j + 1 && testPhrase[k].ToString() == ")" && enabled)
                    {
                        Console.WriteLine("success");
                        var firstNum = int.Parse(testPhrase.Substring(4, j - 4));
                        var secondNum = int.Parse(testPhrase.Substring(j + 1, k - (1 + j)));
                        total += firstNum * secondNum;
                    }
                }
            }
        }
        Console.WriteLine(total);
    }
}