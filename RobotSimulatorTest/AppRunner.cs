using RobotSimulatorTest.Application.Interfaces;
using RobotSimulatorTest.Client.Controllers;
using RobotSimulatorTest.Domain.Enums;
using RobotSimulatorTest.Domain.Exceptions;

namespace RobotSimulatorTest.Client
{
    public class AppRunner(SimulationController simulationController, ILoggerService logger)
    {
        public async Task Run()
        {
            try
            {
                await ExecuteInstuctionsFromFile(simulationController, "InputCommands.txt");
            }
            catch (DataParsingException ex)
            {
                await logger.LogInformation($"Data Parsing Error: {ex.Message}", LogLevel.ERROR);
                return;
            }
            catch (Exception ex)
            {
                await logger.LogInformation($"An error occurred: {ex.Message}", null);
            }
        }

        private async Task ExecuteInstuctionsFromFile(SimulationController controller, string filePath)
        {
            Console.WriteLine($"Executing Instructions from file: {filePath}\n");

            var instructionSet = ReadFromFile(filePath);

            foreach (var instruction in instructionSet)
            {
                await controller.ExecuteInstructionAsync(instruction);
            }
            
            Console.WriteLine("\nExecution complete.");
        }

        private static IEnumerable<string> ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            return File.ReadAllLines(filePath)
                .Where(line => !string.IsNullOrWhiteSpace(line))
                .Select(line => line.Trim());
        }
    }
}
