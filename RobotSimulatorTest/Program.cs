using Microsoft.Extensions.DependencyInjection;
using RobotSimulatorTest.Client;

var services = new ServiceCollection();

// Build the service provider
var serviceProvider = services.BuildServiceProvider();

var runner = serviceProvider.GetRequiredService<AppRunner>();
await runner.Run();
