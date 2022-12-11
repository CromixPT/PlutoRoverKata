namespace PlutoRoverKata.NavigationSystem.Entities;
public sealed class PlanetaryGrid
{
    public int Height { get; init; } = 100;
    public int Width { get; init; } = 100;

    public PlanetaryGrid(int height, int width)
    {
        Height = height;
        Width = width;
    }

    public bool isPositionWithinBounds(Position position)
    {
        if(position.XCoordinate <= 0 || position.YCoordinate <= 0)
        {
            return false;
        }
        return position.XCoordinate <= Height && position.YCoordinate <= Width;
    }
}
