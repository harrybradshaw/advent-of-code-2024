using AdventOfCode2024.Helpers;

namespace AdventOfCode2024.Day_4;

public class WordsearchGrid : Grid
{
    public WordsearchGrid(string input) : base(input)
    {
        
    }
    
    public void FindWord(string word, List<Direction> directions, Action<Direction> onWordFound)
    {
        for (var y = 0; y < _yMax; y++)
        {
            for (var x = 0; x < _xMax; x++)
            {
                if (GetElement(x, y) != word[0]) continue;
                foreach (var direction in directions)
                {
                    var startingChar = GetElementAndSetRef(x, y);
                    var letterCounter = 0;
                    if (startingChar == word[letterCounter])
                    {
                        letterCounter++;
                        while (TryTraverse(direction, out var output) && letterCounter <= word.Length - 1 && word[letterCounter] == output)
                        {
                            if (letterCounter == word.Length - 1)
                            {
                                onWordFound(direction);
                            }
                            letterCounter++;
                        }
                    }
                }
            }
        }
    }
    
    public (int, int) PeekPreviousCoordinates(Direction directionJustMovedIn)
    {
        return directionJustMovedIn switch
        {
            Direction.NorthWest => (_xRef + 1, _yRef + 1),
            Direction.NorthEast => (_xRef - 1, _yRef + 1),
            Direction.SouthEast => (_xRef - 1, _yRef - 1),
            Direction.SouthWest => (_xRef + 1, _yRef - 1),
            _ => throw new ArgumentOutOfRangeException(nameof(directionJustMovedIn), directionJustMovedIn, null)
        };
    }
}