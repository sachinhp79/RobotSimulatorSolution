using Microsoft.Extensions.DependencyInjection;
using RobotSimulatorTest.Application.Interfaces;

namespace RobotSimulatorTest.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDataParser<>), typeof(InputDataParser<>));
            return services;
        }
    }
}
