using RobotSimulatorTest.Application.Interfaces;

namespace RobotSimulatorTest.Client.Controllers
{
    public class SimulationController(ISimulationService simulationService, IInstructionParser instructionParser)
    {
        public async Task ExecuteInstructionAsync(string inputCommand)
        {
            // Implementation for executing commands using _simulationService
            if(simulationService is null) throw new ArgumentNullException(nameof(simulationService));
            if (instructionParser is null) throw new ArgumentNullException(nameof(instructionParser));

            var instruction = await instructionParser.ParseInstructionsAsync(inputCommand);
            
            if(instruction is null)
            {
                throw new InvalidOperationException("Parsed command is null.");
            }
             await instruction.ExecuteInstructionsAsync(simulationService);

        }
    }
}
