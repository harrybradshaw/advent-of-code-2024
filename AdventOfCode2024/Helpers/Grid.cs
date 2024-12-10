namespace AdventOfCode2024.Helpers;

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

    public Dictionary<char, List<Tuple<int, int>>> LocationLookup { get; set; }
    
    public Grid(string input, bool fillLookup = false)
    {
        _grid = [];
        LocationLookup = new Dictionary<char, List<Tuple<int, int>>>();
        using var reader = new StringReader(input);
        while (reader.ReadLine() is { } line)
        {
            if (line.Length > 0)
            {
                _grid.Add(line.ToCharArray().ToList());
                if (fillLookup)
                {
                    for (int i = 0; i < line.Length; i++)
                    {
                        var charToAdd = line[i];
                        if (!LocationLookup.TryAdd(charToAdd, [new(i, _yMax)]))
                        {
                            LocationLookup[charToAdd].Add(new (i, _yMax));
                        }
                    }
                }
                _xMax = line.Length;
            }
            _yMax++;
        }
        
    }

    public Tuple<int, int> GetPosition()
    {
        return new Tuple<int, int>(_xRef, _yRef);
    }

    public char? GetElementOrDefault(int x, int y)
    {
        if (x < 0 || x >= _xMax || y < 0 || y >= _yMax)
        {
            return null;
        }

        return GetElement(x, y);
    }

    public char? GetElementAndSetRef(int x, int y, char? blockingChar = null)
    {
        var element = GetElementOrDefault(x, y);
        if (blockingChar != null && element == blockingChar)
        {
            return element;
        }
        SetRef(x, y);
        return element;
    }

    public char GetElement(int x, int y)
    {
        return _grid[y][x];
    }

    public void SetRef(int x, int y)
    {
        _xRef = x;
        _yRef = y;
    }

    public void SetRef(Tuple<int, int> co)
    {
        SetRef(co.Item1, co.Item2);
    }

    private bool TryTraverse(Direction direction, out char output)
    {
        var x = Traverse(direction);
        if (x == null)
        {
            output = '!';
            return false;
        }

        output = x.GetValueOrDefault();
        return true;
    }

    public char? PeekTraverse(Direction direction, char? blockingChar = null)
    {
        return direction switch
        {
            Direction.North => GetElementOrDefault(_xRef, _yRef - 1),
            Direction.South => GetElementOrDefault(_xRef, _yRef + 1),
            Direction.West => GetElementOrDefault(_xRef - 1, _yRef),
            Direction.East => GetElementOrDefault(_xRef + 1, _yRef),
            Direction.NorthEast => GetElementOrDefault(_xRef + 1, _yRef - 1),
            Direction.NorthWest => GetElementOrDefault(_xRef - 1, _yRef - 1),
            Direction.SouthEast => GetElementOrDefault(_xRef + 1, _yRef + 1),
            Direction.SouthWest => GetElementOrDefault(_xRef - 1, _yRef + 1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    public (int, int) GetCoOrds(Direction direction)
    {
        return direction switch
        {
            Direction.North => (_xRef, _yRef - 1),
            Direction.South => (_xRef, _yRef + 1),
            Direction.West => (_xRef - 1, _yRef),
            Direction.East => (_xRef + 1, _yRef),
            Direction.NorthEast => (_xRef + 1, _yRef - 1),
            Direction.NorthWest => (_xRef - 1, _yRef - 1),
            Direction.SouthEast => (_xRef + 1, _yRef + 1),
            Direction.SouthWest => (_xRef - 1, _yRef + 1),
            _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
        };
    }

    public char? Traverse(Direction direction, char? blockingChar = null)
    {
        return direction switch
        {
            Direction.North => GetElementAndSetRef(_xRef, _yRef - 1, blockingChar),
            Direction.South => GetElementAndSetRef(_xRef, _yRef + 1, blockingChar),
            Direction.West => GetElementAndSetRef(_xRef - 1, _yRef, blockingChar),
            Direction.East => GetElementAndSetRef(_xRef + 1, _yRef, blockingChar),
            Direction.NorthEast => GetElementAndSetRef(_xRef + 1, _yRef - 1, blockingChar),
            Direction.NorthWest => GetElementAndSetRef(_xRef - 1, _yRef - 1, blockingChar),
            Direction.SouthEast => GetElementAndSetRef(_xRef + 1, _yRef + 1, blockingChar),
            Direction.SouthWest => GetElementAndSetRef(_xRef - 1, _yRef + 1, blockingChar),
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

    public (int, int) SetRefOnSingleChar(char character)
    {
        if (LocationLookup.TryGetValue(character, out var locationList) && locationList.Count > 0)
        {
            var location = locationList[0];
            SetRef(location.Item1, location.Item2);
            return (location.Item1, location.Item2);
        }
        
        for (var y = 0; y < _yMax; y++)
        {
            for (var x = 0; x < _xMax; x++)
            {
                if (GetElementAndSetRef(x, y) == character)
                {
                    LocationLookup[character] =
                    [
                        new Tuple<int, int>(x, y)
                    ];
                    return (x, y);
                }
            }
        }

        throw new Exception();
    }
    

    public void PlaceCharAtPosition(int x, int y, char charToPlace)
    {
        _grid[y][x] = charToPlace;
    }
}