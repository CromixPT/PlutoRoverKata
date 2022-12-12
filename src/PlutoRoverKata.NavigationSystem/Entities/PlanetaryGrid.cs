namespace PlutoRoverKata.NavigationSystem.Entities;
public sealed class PlanetaryGrid
{
    public int Height { get; init; } = 100;
    public int Width { get; init; } = 100;

    private readonly IEnumerable<Hazzard> _hazzards = new List<Hazzard>()
    {
        new Hazzard(){Position = new Position(7,3)},
        new Hazzard(){Position = new Position(4,5)},
        new Hazzard(){Position = new Position(6,3)},
        new Hazzard(){Position = new Position(3,3)},
        new Hazzard(){Position = new Position(9,3)}

    };

    public PlanetaryGrid(int height, int width)
    {
        Height = height;
        Width = width;
    }

    private bool IsPositionWithinBounds(Position position)
    {
        if(position.XCoordinate < 0 || position.YCoordinate < 0)
        {
            return false;
        }
        return position.XCoordinate <= Height && position.YCoordinate <= Width;
    }

    private bool IsPositionClear(Position position)
    {
        return !_hazzards.Any(p => p.Position == position);
    }

    public bool IsPositionSafe(Position position)
    {
       return IsPositionClear(position) && IsPositionWithinBounds(position);
    }
}
