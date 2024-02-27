using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Rms
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private HealthCheckService _healthCheckService;
        public Worker(ILogger<Worker> logger, HealthCheckService healthCheckService)
        {
            _logger = logger;
            _healthCheckService = healthCheckService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                if (_logger.IsEnabled(LogLevel.Information))
                {
                    var helth=await _healthCheckService.CheckHealthAsync();
                   _logger.LogInformation("Worker running at: {time} Health:{status}", DateTimeOffset.Now, helth.Status);
                    //Console.WriteLine(helth.Status);
                }
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
