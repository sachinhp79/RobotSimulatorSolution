using RobotSimulatorTest.Domain.Enums;

namespace RobotSimulator.Models;

/// <summary>
/// Represents the toy robot with its position and direction
/// </summary>
public class Robot
{
    public Position? Position { get; private set; }
    public Direction? CurrentDirection { get; private set; }
    public bool IsRobotPlacedOnTable => Position != null && CurrentDirection != null;

    /// <summary>
    /// Places the robot at a specific position and direction
    /// </summary>
    public void Place(Position position, Direction direction)
    {
        Position = position;
        CurrentDirection = direction;
    }

    /// <summary>
    /// Moves the robot one unit forward in the direction it's facing
    /// </summary>
    public Position MoveToNextPosition()
    {
        if (!IsRobotPlacedOnTable)
            throw new InvalidOperationException("Robot must be placed first");

        return CurrentDirection switch
        {
            Direction.NORTH => Position! with { Y = Position.Y + 1 },
            Direction.SOUTH => Position! with { Y = Position.Y - 1 },
            Direction.EAST => Position! with { X = Position.X + 1 },
            Direction.WEST => Position! with { X = Position.X - 1 },
            _ => Position!
        };
    }

    /// <summary>
    /// Updates the robot's position
    /// </summary>
    public void UpdatePosition(Position newPosition)
    {
        Position = newPosition;
    }

    /// <summary>
    /// Rotates the robot 90 degrees to the left
    /// </summary>
    public void TurnLeft()
    {
        if (!IsRobotPlacedOnTable) return;

        CurrentDirection = CurrentDirection switch
        {
            Direction.NORTH => Direction.WEST,
            Direction.WEST => Direction.SOUTH,
            Direction.SOUTH => Direction.EAST,
            Direction.EAST => Direction.NORTH,
            _ => CurrentDirection
        };
    }

    /// <summary>
    /// Rotates the robot 90 degrees to the right
    /// </summary>
    public void TurnRight()
    {
        if (!IsRobotPlacedOnTable) return;

        CurrentDirection = CurrentDirection switch
        {
            Direction.NORTH => Direction.EAST,
            Direction.EAST => Direction.SOUTH,
            Direction.SOUTH => Direction.WEST,
            Direction.WEST => Direction.NORTH,
            _ => CurrentDirection
        };
    }

    /// <summary>
    /// Returns the current state of the robot
    /// </summary>
    public string ReportPosition()
    {
        if (!IsRobotPlacedOnTable)
            return "Please place Robot on the Table and retry.";

        return $"Robot is currently facing in {CurrentDirection} direction and Cordinates are X-Cordinate is {Position?.X}, Y-Cordinate is {Position?.Y}";
    }
}
