using Microsoft.Extensions.DependencyInjection;
using RobotSimulator.Models;
using RobotSimulatorTest.Application.Interfaces;
using RobotSimulatorTest.Client;
using RobotSimulatorTest.Client.Controllers;
using RobotSimulatorTest.Infrastructure;
using RobotSimulatorTest.Infrastructure.Factories;
using RobotSimulatorTest.Infrastructure.Services;

namespace MissingNumberSolution.Client
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyRegistrations(this IServiceCollection services)
        {
            services.AddDomainServices();
            services.AddApplicationServices();
            services.AddInfrastructureServices();
            services.AddPresentationServices();
            return services;
        }

        /// <summary>
        /// Registers Domain layer dependencies
        /// </summary>
        private static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            // Register domain entities as scoped
            services.AddScoped<Robot>();
            services.AddScoped<Table>(sp => new Table(5, 5));

            return services;
        }

        /// <summary>
        /// Registers Application layer dependencies
        /// </summary>
        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Application services
            services.AddScoped<ISimulationService, SimulationService>();

            return services;
        }

        /// <summary>
        /// Registers Infrastructure layer dependencies
        /// </summary>
        private static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // Parsers
            services.AddScoped<IInstructionParser, InstructionParser>();

            // Factories
            services.AddScoped<IInstructionFactory, InstructionFactory>();

            // Infrastructure services
            services.AddSingleton<ILoggerService, LoggerService>();

            return services;
        }

        /// <summary>
        /// Registers Presentation layer dependencies
        /// </summary>
        private static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            // Controllers
            services.AddScoped<SimulationController>();

            // App Runner
            services.AddTransient<AppRunner>();

            return services;
        }
    }
}