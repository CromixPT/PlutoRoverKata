using Microsoft.Extensions.Options;
using PlutoRoverKata.NavigationSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRoverKata.NavigationSystem.Entities;
public class Navigator
{

    private const char MoveForward = 'F';
    private const char MoveBackward = 'B';
    private const char RotateLeft = 'L';
    private const char RotateRight = 'R';
    

	private readonly PlanetaryVehicle _vehicle;
	private readonly PlanetaryGrid _planetaryGrid;

    private readonly RoverOptions _roverOptions;
    private readonly PlanetaryGridOptions _gridOptions;

    public Navigator(IOptions<RoverOptions> roverOptions, IOptions<PlanetaryGridOptions> gridOptions)
    {

        _roverOptions = roverOptions.Value;
        _gridOptions = gridOptions.Value;

        _vehicle = new Rover(1, _roverOptions.Position, _roverOptions.Direction);
        _planetaryGrid = new PlanetaryGrid(_gridOptions.Height, _gridOptions.Widht);
        
    }


    public Position ProcessReceivedInstructions(string instructions)
    {
        foreach (var instruction in instructions.ToUpperInvariant())
        {
            switch (instruction) {
                case MoveForward:
                    PerformActionIfSafe(RoverActions.MoveForward);
                    break;
                case MoveBackward:
                    PerformActionIfSafe(RoverActions.MoveBackward);
                    break;
                case RotateLeft:
                    _vehicle.RotateLeft();
                    break;
                case RotateRight:
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
