using Microsoft.Extensions.DependencyInjection;
using MissingNumberSolution.Client;
using RobotSimulatorTest.Client;

var services = new ServiceCollection();

// Register the dependencies for DI
services.AddDependencyRegistrations();

// Build the service provider
var serviceProvider = services.BuildServiceProvider();

var runner = serviceProvider.GetRequiredService<AppRunner>();
await runner.Run();
