using RobotSimulatorTest.Application.Interfaces;

namespace RobotSimulatorTest.Application.Commands
{
    public class SendReport : IInstruction
    {
        public Task ExecuteInstructionsAsync(ISimulationService simulationService)
        {
            simulationService.ReportRobotStatus();
            return Task.CompletedTask;
        }
    }
}
