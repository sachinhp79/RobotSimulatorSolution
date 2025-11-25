using System;
namespace RobotSimulatorTest.Application.Interfaces;

public interface IInstructionParser
{
    Task<IInstruction> ParseInstructionsAsync(string input);
}
