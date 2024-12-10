namespace AdventOfCode2024.Helpers;

public enum Direction
{
    North, South, East, West, NorthEast, NorthWest, SouthEast, SouthWest
}

public class Grid
{
    protected int _xRef = 0;
    protected int _yRef = 0;

    protected readonly int _xMax = 0;
    protected readonly int _yMax = 0;
    
    private readonly List<List<char>> _grid;
    private readonly Dictionary<char, List<Tuple<int, int>>> _locationDictionary;
    
    public Grid(string input)
    {
        _grid = [];
        _locationDictionary = new Dictionary<char, List<Tuple<int, int>>>();
        using var reader = new StringReader(input);
        while (reader.ReadLine() is { } line)
        {
            if (line.Length > 0)
            {
                _grid.Add(line.ToCharArray().ToList());
                for (var i = 0; i < line.Length; i++)
                {
                    var charToAdd = line[i];
                    if (!_locationDictionary.TryAdd(charToAdd, [new(i, _yMax)]))
                    {
                        _locationDictionary[charToAdd].Add(new (i, _yMax));
                    }
                }
                _xMax = line.Length;
            }
            _yMax++;
        }
    }

    public Tuple<int, int> GetCurrentPosition()
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

    public char? GetElementOrDefault((int x, int y) coords)
    {
        return GetElementOrDefault(coords.x, coords.y);
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

    public List<Tuple<int, int>> GetLocations(char characterToFind)
    {
        return _locationDictionary[characterToFind];
    }

    public void SetRef(Tuple<int, int> coords)
    {
        SetRef(coords.Item1, coords.Item2);
    }

    private void SetRef(int x, int y)
    {
        _xRef = x;
        _yRef = y;
    }

    protected bool TryTraverse(Direction direction, out char output)
    {
        var characterAtNewCoords = Traverse(direction);
        if (characterAtNewCoords == null)
        {
            output = '!';
            return false;
        }

        output = characterAtNewCoords.GetValueOrDefault();
        return true;
    }

    public char? PeekNextElement(Direction direction)
    {
        return GetElementOrDefault(PeekNextCoordinates(direction));
    }

    public (int, int) PeekNextCoordinates(Direction direction)
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
        var (x, y) = PeekNextCoordinates(direction);
        return GetElementAndSetRef(x, y, blockingChar);
    }
    
    

    public void PlaceCharAtPosition(int x, int y, char charToPlace)
    {
        // LocationLookup not valid post doing this.
        _grid[y][x] = charToPlace;
    }
}