using PlutoRoverKata.NavigationSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRoverKata.NavigationSystem.Entities;
public sealed class Rover : PlanetaryVehicle
{

    public Rover(int Id,Position position, Direction direction):base(Id, position, direction)
    {

    }

    public override void RotateLeft()
    {
        Direction = Direction switch
        {
            Direction.North => Direction.West,
            Direction.East => Direction.North,
            Direction.South => Direction.East,
            Direction.West => Direction.South,
            _ => throw new NotImplementedException(),
        };
    }

    public override void RotateRight()
    {
        Direction = Direction switch
        {
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            Direction.West => Direction.North,
            _ => throw new NotImplementedException(),
        };
    }

    public override Position PlanMove(RoverActions action)
    {
        var position = Position.ClonePosition();
        switch (action)
        {
            case RoverActions.MoveForward:
                position = PositionAfterMovement(position);
                break;
            case RoverActions.MoveBackward:
                FlipDirection();
                position = PositionAfterMovement(position);
                FlipDirection();
                break;
            default:
                return Position;
        }
        return position;

    }

    public override void UpdatePosition(Position position)
    {
        Position = position;

    }

    private Position PositionAfterMovement(Position position)
    {
        switch (Direction)
        {
            case Direction.North:
                position.IncreaseY();
                break;
            case Direction.East:
                position.IncreaseX();
                break;
            case Direction.South:
                position.DecreaseY();
                break;
            case Direction.West:
                position.DecreaseX();
                break;
            default:
                break;
        }

        return position;
    }

    private void FlipDirection()
    {
        Direction = Direction switch
        {
            Direction.North => Direction.South,
            Direction.East => Direction.West,
            Direction.South => Direction.North,
            Direction.West => Direction.East,
            _ => throw new NotImplementedException(),
        };
    }
}
