namespace RobotSimulator.Models;

/// <summary>
/// Represents a position on the table with X and Y coordinates
/// </summary>
public record Position(int X, int Y)
{
    public override string ToString() => $"{X},{Y}";
}
