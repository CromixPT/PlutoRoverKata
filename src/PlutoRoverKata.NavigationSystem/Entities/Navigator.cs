using PlutoRoverKata.NavigationSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRoverKata.NavigationSystem.Entities;
public class Navigator
{

    private const char _moveForward = 'F';
    private const char _moveBackward = 'B';
    private const char _rotateLeft = 'L';
    private const char _rotateRight = 'R';
    

	private readonly PlanetaryVehicle _vehicle;
	private readonly PlanetaryGrid _planetaryGrid;

	public Navigator(PlanetaryVehicle rover, PlanetaryGrid planetaryGrid)
    {
        _vehicle = rover;
        _planetaryGrid = planetaryGrid;
    }


    public Position ProcessReceivedInstructions(string instructions)
    {
        foreach (var instruction in instructions.ToUpperInvariant())
        {
            switch (instruction) {
                case _moveForward:
                    PerformActionIfSafe(RoverActions.MoveForward);
                    break;
                case _moveBackward:
                    PerformActionIfSafe(RoverActions.MoveBackward);
                    break;
                case _rotateLeft:
                    _vehicle.RotateLeft();
                    break;
                case _rotateRight:
                    _vehicle.RotateRight();
                    break;
                default:
                    break;
            }
        }

        return _vehicle.Position;
    }

    public Position LocateVehicle()
    {
        return _vehicle.Position;
    }

    public Direction GetVehicleFacingDirection()
    {
        return _vehicle.Direction;
    }

    private void PerformActionIfSafe(RoverActions action)
    {
        var newPosition = _vehicle.PlanMove(action);
        if (_planetaryGrid.IsPositionSafe(newPosition))
        {
            _vehicle.UpdatePosition(newPosition);
        }
    }
}
