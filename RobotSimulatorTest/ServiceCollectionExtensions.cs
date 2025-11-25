using Microsoft.Extensions.DependencyInjection;
using RobotSimulator.Models;
using RobotSimulatorTest.Application.Interfaces;
using RobotSimulatorTest.Client;
using RobotSimulatorTest.Client.Controllers;
using RobotSimulatorTest.Infrastructure;
using RobotSimulatorTest.Infrastructure.Services;

namespace MissingNumberSolution.Client
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyRegistrations(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddScoped<IDataParser<string>, InputDataParser<string>>();
            services.AddScoped(sp => new Table(5, 5));
            services.AddScoped<SimulationController>(sp => 
                new SimulationController(
                    sp.GetRequiredService<ISimulationService>(),
                    sp.GetRequiredService<IInstructionParser>())
                );
            services.AddScoped<IInstructionParser, InstructionParser>();
            services.AddTransient<AppRunner>();

            return services;
        }
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ISimulationService, SimulationService>();
            return services;
        }

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services;
        }
    }
}