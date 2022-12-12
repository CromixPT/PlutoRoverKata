namespace PlutoRoverKata.NavigationSystem.Entities;
public sealed class Position : IEquatable<Position>
{
    public int XCoordinate { get; private set; }
    public int YCoordinate { get; private set; }

    public Position(int x, int y)
    {
        XCoordinate= x;
        YCoordinate= y;
    }

    public Position ClonePosition()
    {
        return new Position(XCoordinate, YCoordinate);
    }

    public void IncreaseX() => XCoordinate++;
    public void DecreaseX() => XCoordinate--;
    public void IncreaseY() => YCoordinate++;
    public void DecreaseY() => YCoordinate--;
    public (int x, int y) GetPosition() => (XCoordinate, YCoordinate);

    public static bool operator ==(Position? left, Position? right)
    {
        return left is not null && right is not null && left.Equals(right);
    }

    public static bool operator !=(Position? left, Position? right)
    {
        return !(left == right);
    }

    public override bool Equals(object? obj)
    {
        if(obj is null)
        {
            return false;
        }

        if(obj.GetType() != GetType())
        {
            return false;
        }

        if(obj is not Position position)
        {
            return false;
        }

        return XCoordinate==position.XCoordinate && YCoordinate==position.YCoordinate;

    }

    public bool Equals(Position? other)
    {
        if (other is null)
        {
            return false;
        }

        return XCoordinate == other.XCoordinate && YCoordinate == other.YCoordinate;
    }

    public override int GetHashCode()
    {
        return XCoordinate.GetHashCode() * YCoordinate.GetHashCode();
    }

    public override string ToString()
    {
        return $"{XCoordinate}:{YCoordinate}";
    }

}
