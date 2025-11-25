using RobotSimulatorTest.Application.Commands;
using RobotSimulatorTest.Application.Interfaces;

namespace RobotSimulatorTest.Infrastructure;

public class InstructionParser(IInstructionFactory instructionFactory) : IInstructionParser
{
    public async Task<IInstruction> ParseInstructionsAsync(string input)
    {
        var instruction = instructionFactory.CreateInstruction(input);
        return instruction!;
    }
}
