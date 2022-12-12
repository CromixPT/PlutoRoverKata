using FluentAssertions;
using PlutoRoverKata.NavigationSystem.Entities;
using PlutoRoverKata.NavigationSystem.Enums;

namespace PlutoRoverKata.NavigationSystem.Test.RoverTests;
public class RoverTests
{

    private readonly Position _startingPosition = new Position(10, 10);

    //Given a start position and direction, rover moves foward the expected position be differnt and same direction
    [Theory]
    [MemberData(nameof(RoverFowardMoveTests))]
    public void RoverIssuedMoveFowardCommandShouldUpdatePosition(Direction startingDirection, Position expectedPosition )
    {
        //Arrange
        var rover = new Rover(1, _startingPosition,startingDirection);
        //Act
        var position = rover.PlanMove(RoverActions.MoveForward);
        rover.UpdatePosition(position);

        //Assert
        rover.Position.Should().Be(expectedPosition);
        rover.Direction.Should().Be(startingDirection);


    }

    //Given a start position and direction, rover moves backward the expected position be differnt and same direction
    [Theory]
    [MemberData(nameof(RoverBackardsMoveTests))]
    public void RoverIssuedMoveBackwardsFowardCommandShouldUpdatePosition(Direction startingDirection, Position expectedPosition)
    {
        //Arrange
        var rover = new Rover(1, _startingPosition, startingDirection);
        //Act
        var position = rover.PlanMove(RoverActions.MoveBackward);
        rover.UpdatePosition(position);

        //Assert
        rover.Position.Should().Be(expectedPosition);
        rover.Direction.Should().Be(startingDirection);


    }

    //Rover rotates left direction should update
    [Theory]
    [InlineData(Direction.North,Direction.West)]
    [InlineData(Direction.East,Direction.North)]
    [InlineData(Direction.South,Direction.East)]
    [InlineData(Direction.West,Direction.South)]
    public void RoverIssuedRotateLeftCommandShouldRotate(Direction startingDirection, Direction expectedDirection)
    {
        //Arrange
        var rover = new Rover(1,_startingPosition, startingDirection);

        //Act
        rover.RotateLeft();

        //Assert
        rover.Position.Should().Be(_startingPosition);
        rover.Direction.Should().Be(expectedDirection);
    }

    [Theory]
    [InlineData(Direction.North, Direction.East)]
    [InlineData(Direction.East, Direction.South)]
    [InlineData(Direction.South, Direction.West)]
    [InlineData(Direction.West, Direction.North)]
    public void RoverIssuedRotateRightCommandShouldRotate(Direction startingDirection, Direction expectedDirection)
    {
        //Arrange
        var rover = new Rover(1, _startingPosition, startingDirection);

        //Act
        rover.RotateRight();

        //Assert
        rover.Position.Should().Be(_startingPosition);
        rover.Direction.Should().Be(expectedDirection);
    }

    [Fact]
    public void RoverIssuedPlanMoveCommandShouldNotUpdatePosition()
    {
        var rover = new Rover(1,_startingPosition,Direction.North);

        var result = rover.PlanMove(RoverActions.MoveForward);

        result.YCoordinate.Should().Be(11);
        rover.Position.Should().Be(_startingPosition);

    }


    public static IEnumerable<Object[]> RoverFowardMoveTests()
    {
        yield return new Object[] {Direction.North, new Position(10,11)};
        yield return new Object[] { Direction.East, new Position(11, 10) };
        yield return new Object[] { Direction.South, new Position(10, 9) };
        yield return new Object[] { Direction.West, new Position(9, 10) };
    }
     
    public static IEnumerable<Object[]> RoverBackardsMoveTests()
    {
        yield return new Object[] {Direction.North, new Position(10,9)};
        yield return new Object[] {Direction.East, new Position(9,10)};
        yield return new Object[] {Direction.South, new Position(10,11)};
        yield return new Object[] {Direction.West, new Position(11,10)};
    }
}
