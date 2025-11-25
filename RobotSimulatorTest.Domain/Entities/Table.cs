namespace RobotSimulator.Models;

/// <summary>
/// Represents the table surface with defined boundaries e.g., 5x5 units
/// </summary>
public class Table(int width, int height)
{
    //if (width <= 0 || height <= 0)
    //    throw new ArgumentException("Table dimensions must be positive");

    public int Width { get; } = width;
    public int Height { get; } = height;

    /// <summary>
    /// Checks if a position is valid (within table boundaries)
    /// </summary>
    public bool IsValidPosition(Position position)
    {
        return position.X >= 0 && position.X < Width &&
               position.Y >= 0 && position.Y < Height;
    }
}
