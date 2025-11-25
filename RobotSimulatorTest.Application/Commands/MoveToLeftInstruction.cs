using RobotSimulatorTest.Application.Interfaces;

namespace RobotSimulatorTest.Application.Commands
{
    public class MoveToLeftInstruction : IInstruction
    {
        public Task ExecuteInstructionsAsync(ISimulationService simulationService)
        {
            simulationService.MoveRobotToLeft();
            return Task.CompletedTask;
        }
    }
}
        