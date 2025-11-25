using RobotSimulatorTest.Application.Commands;
using RobotSimulatorTest.Application.Interfaces;
using RobotSimulatorTest.Domain.Enums;

namespace RobotSimulatorTest.Infrastructure.Factories;

public class InstructionFactory : IInstructionFactory
{
    public IInstruction? CreateInstruction(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return null;

        var instruction = input.Trim().ToUpperInvariant();

        if (instruction.StartsWith("PLACE"))
        {
            return CreatePlaceInstruction(instruction);
        }

        return instruction switch
        {
            "MOVE" => new MoveInstruction(),
            "LEFT" => new MoveToLeftInstruction(),
            "RIGHT" => new MoveToRightInstruction(),
            "REPORT" => new SendReport(),
            _ => null
        };
    }

    private IInstruction? CreatePlaceInstruction(string instruction)
    {
        var parts = instruction.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);

        if (parts.Length != 2)
            return null;

        var parameters = parts[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

        if (parameters.Length != 3)
            return null;

        if (!int.TryParse(parameters[0].Trim(), out int x))
            return null;

        if (!int.TryParse(parameters[1].Trim(), out int y))
            return null;

        if (!Enum.TryParse<Direction>(parameters[2].Trim(), true, out Direction direction))
            return null;

        return new PlaceInstruction(x, y, direction);
    }
}