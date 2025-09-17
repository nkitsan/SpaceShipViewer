using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpaceShipViewer.SpaceX.Workers.Configurations;
using SpaceShipViewer.SpaceX.Workers.Services;

namespace SpaceShipViewer.SpaceX.Workers.Workers
{
    public class LaunchesWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly LaunchesWorkerConfiguration _configuration;
        private readonly ILogger<LaunchesWorker> _logger;

        public LaunchesWorker(
            IServiceProvider serviceProvider,
            IOptions<LaunchesWorkerConfiguration> options,
            ILogger<LaunchesWorker> logger)
        {
            _serviceProvider = serviceProvider;
            _configuration = options.Value;
            _logger = logger;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var _launchesService = scope.ServiceProvider.GetRequiredService<ILaunchesService>();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await _launchesService.SaveLatestUpdates();

                    await Task.Delay(TimeSpan.FromSeconds(_configuration.IntervalInSeconds), stoppingToken);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, ex.Message);
                }
            }
        }
    }
}
