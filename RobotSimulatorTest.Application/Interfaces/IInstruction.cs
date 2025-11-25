namespace RobotSimulatorTest.Application.Interfaces;

public interface IInstruction
{
    Task ExecuteInstructionsAsync(ISimulationService simulatioService);
}

