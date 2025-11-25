namespace RobotSimulatorTest.Application.Interfaces;

public interface IInstructionFactory
{
    IInstruction? CreateInstruction(string input);
}