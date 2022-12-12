using PlutoRoverKata.NavigationSystem.Enums;

namespace PlutoRoverKata.NavigationSystem.Entities;
public abstract class PlanetaryVehicle : IEquatable<PlanetaryVehicle>
{
    public int Id { get; private set; }
    public Position Position { get; protected set; }
    public Direction Direction { get; protected set; }

    public PlanetaryVehicle(int id, Position position, Direction direction)
    {
        Id= id;
        Position = position;
        Direction=direction;
    }

    public bool Equals(PlanetaryVehicle? other)
    {
        if(other is null)
        {
            return false;
        }

        return other.Id == Id;


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

        if(obj is not PlanetaryVehicle vehicle)
        {
            return false;
        }

        return Id == vehicle.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public abstract void RotateLeft();
    public abstract void RotateRight();
    public abstract Position PlanMove(RoverActions action);
    public abstract void UpdatePosition(Position position);
}
