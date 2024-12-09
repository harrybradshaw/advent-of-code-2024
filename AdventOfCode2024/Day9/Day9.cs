using System.Text;

namespace AdventOfCode2024.Day9;

public static class Day9
{
    public static void Part1(string input)
    {
        var (blocks, queue) = GenerateSingleBlocks(input);
        for (int i = blocks.Count - 1; i >= 0; i--)
        {
            GenerateStringRep(blocks);
            if (blocks[i].FileId == null)
            {
                continue;
            }
            var newIndex = queue.Dequeue();
            if (newIndex > i)
            {
                break;
            }
            blocks[newIndex] = blocks[i];
            blocks[i] = new Block
            {
                FileId = null,
            };
        }
        GenerateChecksum(blocks);
    }
    
    public static void Part2(string input)
    {
        var (blocks, queue) = GenerateSingleBlocks(input);
        var listOfEmptyIndices = queue.ToList();
        for (var i = blocks.Count - 1; i >= 0; i--)
        {
            int? removalIndex = null;
            var blockToMove = blocks[i];
            if (blockToMove.FileId == null)
            {
                continue;
            }

            for (var k = 0; k < listOfEmptyIndices.Count; k++)
            {
                var emptyIndex = listOfEmptyIndices[k];
                var emptyBlock = blocks[emptyIndex];
                
                if (emptyIndex > i)
                {
                    break;
                }

                var emptySize = emptyBlock.Size;
                var sizeDiff = emptyBlock.Size - blockToMove.Size;
                if (sizeDiff >= 0)
                {
                    for (var j = 0; j < emptySize; j++)
                    {
                        blocks[emptyIndex + j].Size = sizeDiff;
                    }
                    
                    
                    for (var j = 0; j < blockToMove.Size; j++)
                    {
                        blocks[emptyIndex + j] = blocks[i - j];
                        blocks[i - j] = new Block
                        {
                            FileId = null,
                        };
                    }
                    
                    removalIndex = k;
                    break;
                }
            }

            i = i - blockToMove.Size + 1; // Move the pointer along.
            if (removalIndex.HasValue)
            {
                listOfEmptyIndices.RemoveRange(removalIndex.Value, blockToMove.Size);
            }
        }

        GenerateChecksum(blocks);
    }
    
    private static void GenerateStringRep(List<Block> blocks, bool useSize = false)
    {
        Console.WriteLine(blocks.Aggregate("", ((s, block) => s + new StringBuilder().Insert(0, (block.FileId?.ToString() ?? "."), useSize ? block.Size : 1))));
    }

    private static void GenerateChecksum(List<Block> blocks)
    {
        long cs = 0;
        for (int i = 0; i < blocks.Count; i++)
        {
            if (!blocks[i].FileId.HasValue)
            {
                continue;
            }

            cs += i * blocks[i].FileId.Value;
        }
        Console.WriteLine(cs);
    }

    private static (List<Block>, Queue<int>) GenerateSingleBlocks(string input)
    {
        var blocks = new List<Block>();
        var queue = new Queue<int>();

        var chars = input.ToCharArray();
        for (int i = 0; i < chars.Length; i++)
        {
            var isEmptySpace = i % 2 == 1;
            var fileId = i / 2;

            for (int j = 0; j < int.Parse(chars[i].ToString()); j++)
            {
                if (isEmptySpace)
                {
                    queue.Enqueue(blocks.Count);
                }
                blocks.Add(new Block
                {
                    FileId = isEmptySpace ? null : fileId,
                    Size = int.Parse(chars[i].ToString()),
                });

            }
        }

        return (blocks, queue);
    }
}