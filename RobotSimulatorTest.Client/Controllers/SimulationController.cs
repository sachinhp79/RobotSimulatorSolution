using RobotSimulatorTest.Application.Interfaces;

namespace RobotSimulatorTest.Client.Controllers
{
    public class SimulationController(ISimulationService simulationService, IInstructionParser instructionParser)
    {
        public async Task ExecuteInstructionAsync(string inputCommand)
        {
            if (simulationService is null) throw new ArgumentNullException(nameof(simulationService));
            if (instructionParser is null) throw new ArgumentNullException(nameof(instructionParser));

            var instruction = await instructionParser.ParseInstructionsAsync(inputCommand);
            
            if (instruction is null)
            {
                Console.WriteLine($"Invalid command, discarding the command: {inputCommand}");
                return;
            }
            
            await instruction.ExecuteInstructionsAsync(simulationService);
        }
    }
}
