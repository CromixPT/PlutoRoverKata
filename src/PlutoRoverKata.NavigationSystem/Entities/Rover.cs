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

    public override void MoveBackards()
    {
        //Move backwards rotates the rover moves forwards and then rotates back to original direction.
        FlipDirection();
        Move();
        FlipDirection();
    }

    public override void MoveForward()
    {
        Move();
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

    private void Move()
    {
        switch (Direction)
        {
            case Direction.North:
                Position.IncreaseY();
                break;
            case Direction.East:
                Position.IncreaseX();
                break;
            case Direction.South:
                Position.DecreaseY();
                break;
            case Direction.West:
                Position.DecreaseX();
                break;
            default:
                break;
        }
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
