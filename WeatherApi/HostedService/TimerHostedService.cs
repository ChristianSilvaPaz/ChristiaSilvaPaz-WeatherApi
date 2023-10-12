using WeatherApi.Interfaces.Repositories;

namespace WeatherApi.HostedService;

public class TimerHostedService : IHostedService
{
    private const int CacheTime = 20;

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<TimerHostedService> _logger; 

    public TimerHostedService(IServiceProvider serviceProvider, ILogger<TimerHostedService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        new Timer(ExecuteProcess, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        return Task.CompletedTask;
    }

    private async void ExecuteProcess(object? state)
    {
        var finishCacheDate = DateTime.Now.AddMinutes(-CacheTime);

        using (IServiceScope scope = _serviceProvider.CreateScope())
        {
            _logger.LogInformation($"{DateTime.Now}");

            IWeatherRepository weatherRepository =
                scope.ServiceProvider.GetRequiredService<IWeatherRepository>();

            await weatherRepository.DeleteByCacheDateAsync(finishCacheDate);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
