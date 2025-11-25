using RobotSimulatorTest.Application.Interfaces;

namespace RobotSimulatorTest.Application.Commands
{
    public class MoveToRightInstruction : IInstruction
    {
        public Task ExecuteInstructionsAsync(ISimulationService simulationService)
        {
            simulationService.MoveRobotToRight();
            return Task.CompletedTask;
        }
    }
}
