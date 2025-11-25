namespace RobotSimulatorTest.Domain.Exceptions;

/// <summary>
/// Represents errors that occur during data parsing in the infrastructure layer.
/// </summary>
public class DataParsingException : Exception
{
    public DataParsingException(string message)
        : base(message) { }

    public DataParsingException(string message, Exception innerException)
        : base(message, innerException) { }

    /// <summary>
    /// Optionally, you can provide additional context, such as the source or line number.
    /// </summary>
    public string? SourceFile { get; set; }
    public int? LineNumber { get; set; }
}