namespace AdventOfCode2024.Day4;

public enum Direction
{
    North, South, East, West, NorthEast, NorthWest, SouthEast, SouthWest
}

public class Grid
{
    private int _xRef = 0;
    private int _yRef = 0;

    private readonly int _xMax = 0;
    private readonly int _yMax = 0;
    
    private readonly List<List<char>> _grid;
    
    public Grid(string input)
    {
        _grid = [];
        using var reader = new StringReader(input);
        while (reader.ReadLine() is { } line)
        {
            if (line.Length > 0)
            {
                _grid.Add(line.ToCharArray().ToList());
                _xMax = line.Length;
            }
            _yMax++;
        }
        
    }

    private char? GetElementAndSetRef(int x, int y)
    {
        if (x < 0 || x >= _xMax || y < 0 || y >= _yMax)
        {
            return null;
        }
        SetRef(x, y);
        return GetElement(x, y);
    }

    private char GetElement(int x, int y)
    {
        return _grid[y][x];
    }

    private void SetRef(int x, int y)
    {
        _xRef = x;
        _yRef = y;
    }

    private bool TryTraverse(Direction direction, out char output)
    {
        var x = Traverse(direction);
        if (x == null)
        {
            output = '#';
            return false;
        }

        output = x.GetValueOrDefault();
        return true;
    }

    private char? Traverse(Direction direction)
    {
        return direction switch
        {
            Direction.North => GetElementAndSetRef(_xRef, _yRef - 1),
            Direction.South => GetElementAndSetRef(_xRef, _yRef + 1),
            Direction.West => GetElementAndSetRef(_xRef - 1, _yRef),
            Direction.East => GetElementAndSetRef(_xRef + 1, _yRef),
            Direction.NorthEast => GetElementAndSetRef(_xRef + 1, _yRef - 1),
            Direction.NorthWest => GetElementAndSetRef(_xRef - 1, _yRef - 1),
            Direction.SouthEast => GetElementAndSetRef(_xRef + 1, _yRef + 1),
            Direction.SouthWest => GetElementAndSetRef(_xRef - 1, _yRef + 1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    public (int, int) GetPrevious(Direction direction)
    {
        return direction switch
        {
            Direction.NorthWest => (_xRef + 1, _yRef + 1),
            Direction.NorthEast => (_xRef - 1, _yRef + 1),
            Direction.SouthEast => (_xRef - 1, _yRef - 1),
            Direction.SouthWest => (_xRef + 1, _yRef - 1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }
    
    public void FindWord(string word, List<Direction> directions, Action<Grid, Direction> onWordFound)
    {
        for (var y = 0; y < _yMax; y++)
        {
            for (var x = 0; x < _xMax; x++)
            {
                if (GetElement(x,y) == word[0])
                {
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
                                    onWordFound(this, direction);
                                }
                                letterCounter++;
                            }
                        }
                    }
                }
            }
        }
    }
}