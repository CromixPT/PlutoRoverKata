using FluentAssertions;
using PlutoRoverKata.NavigationSystem.Entities;
using PlutoRoverKata.NavigationSystem.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlutoRoverKata.NavigationSystem.Test.NavigatorTests;
public class NavigatorTests
{
    private readonly Navigator _navigator;
    
    public NavigatorTests()
    {
        var startPosition = new Position(0, 0);
        var rover = new Rover(1, startPosition, Direction.North);
        var planetaryGrid = new PlanetaryGrid(10, 10);


        _navigator = new Navigator(rover, planetaryGrid);
    }


    [Theory]
    [InlineData("F")]
    [InlineData("f")]
    public void SingleInstructionPerformsVehicleAction(string instruction)
    {
        //act
        var position = _navigator.ProcessReceivedInstructions(instruction);


        //assert
        position.Should().Be(new Position(0, 1));

    }

    [Theory]
    [InlineData("FFFFF")]
    [InlineData("fffff")]
    public void MultipleInstructionPerformsVehicleAction(string instruction)
    {
        //act
        var position = _navigator.ProcessReceivedInstructions(instruction);


        //assert
        position.Should().Be(new Position(0, 5));
    }

    [Theory]
    [MemberData(nameof(OffGridTests))]
    public void RoverShouldRemainInsideThePlanetaryGrid(string instruction, Position expectedPosition)
    {
        //act
        var position = _navigator.ProcessReceivedInstructions(instruction);

        //assert
        position.Should().Be(expectedPosition);
    }

    [Theory]
    [MemberData(nameof(HappyScenarioTests))]
    public void ProcessValidInstructionsShouldMoveRoverPositionAndFacingDirection(string instruction, Position expectedPosition, Direction expectedFacingDirection)
    {
        
        var position = _navigator.ProcessReceivedInstructions(instruction);

        position.Should().Be(expectedPosition);
        _navigator.GetVehicleFacingDirection().Should().Be(expectedFacingDirection);
    }

    [Theory]
    [MemberData(nameof(HazzardTests))]
    public void ProcessValidInstructionsShouldMoveRoverIntoUnsafePosition(string instruction, Position expectedPosition, Direction expectedFacingDirection)
    {

        var position = _navigator.ProcessReceivedInstructions(instruction);

        position.Should().Be(expectedPosition);
        _navigator.GetVehicleFacingDirection().Should().Be(expectedFacingDirection);
    }

    public static IEnumerable<object[]> OffGridTests()
    {
        yield return new object[] { new string('F', 11), new Position(0, 10) };
        yield return new object[] { "LFF", new Position(0, 0) };
        yield return new object[] { "B", new Position(0, 0) };
        yield return new object[] { "RB", new Position(0, 0) };
    }

    public static IEnumerable<object[]> HazzardTests()
    {
        yield return new object[] { "FFFRFFFF", new Position(2, 3), Direction.East };
    }


    public static IEnumerable<object[]> HappyScenarioTests()
    {

        yield return new object[] { "RFFLFF" , new Position(2, 2), Direction.North };
        yield return new object[] { "RRRR", new Position(0, 0), Direction.North };
        yield return new object[] { "FFFFFFFFFFRFFFFFFFFFFRFFFFFFFFFFRFFFFFFFFFFR", new Position(0, 0), Direction.North };
        yield return new object[] { "FB", new Position(0, 0), Direction.North };
        yield return new object[] { "FLLF", new Position(0, 0), Direction.South };
        yield return new object[] { "RFFFFFLFFFFF", new Position(5, 5), Direction.North };
        yield return new object[] { "RFFLFFFB", new Position(2, 2), Direction.North };

    }

}
