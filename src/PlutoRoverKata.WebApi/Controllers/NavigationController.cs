using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlutoRoverKata.NavigationSystem.Entities;
using PlutoRoverKata.NavigationSystem.Enums;
using PlutoRoverKata.WebApi.Commands;

namespace PlutoRoverKata.WebApi.Controllers;
[Route("api/v1/[controller]")]
[ApiController]
public class NavigationController : ControllerBase
{
	private readonly Navigator _navigator;
    private readonly ILogger<NavigationController> _logger;

    public NavigationController(Navigator navigator, ILogger<NavigationController> logger)
    {
        _navigator = navigator;
        _logger = logger;
    }


    [HttpPost]
    public Position Instructions([FromBody] VehicleInstructionsCommand command)
    {
        _logger.LogInformation("Received Vehicle Instructions. Position will update shortly");

        var position = _navigator.ProcessReceivedInstructions(command.Instructions);

        _logger.LogInformation("Vehicle position updated, can be located at grid {Position}", position);
        return position;
    }

    [HttpGet("position")]
    public Position GetPosition()
    {
        return _navigator.LocateVehicle();
    }


    [HttpGet("direction")]
    public Direction GetDirection()
    {
        return _navigator.GetVehicleFacingDirection();
    }
}
