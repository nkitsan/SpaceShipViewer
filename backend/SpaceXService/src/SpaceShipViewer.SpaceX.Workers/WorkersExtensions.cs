using Microsoft.Extensions.DependencyInjection;
using Oddity;
using SpaceShipViewer.SpaceX.Workers.Mappers;
using SpaceShipViewer.SpaceX.Workers.Services;
using SpaceShipViewer.SpaceX.Workers.Workers;

namespace SpaceShipViewer.SpaceX.Workers
{
    public static class WorkersExtensions
    {
        public static IServiceCollection AddWorkerServices(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddScoped<OddityCore, OddityCore>()
                .AddScoped<ILaunchesService, LaunchesService>()
                .AddAutoMapper(typeof(WorkerServicesProfile))
                .AddHostedService<LaunchesWorker>();
        }
    }
}
