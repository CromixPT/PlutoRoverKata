using PlutoRoverKata.NavigationSystem.Entities;
using PlutoRoverKata.NavigationSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRoverKata.NavigationSystem;
public sealed class RoverOptions
{
    public static string ConfigurationKey = "Rover";

    public Position Position { get; set; } = null!;
    public Direction Direction { get; set; }
}
