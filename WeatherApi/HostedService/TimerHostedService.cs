using WeatherApi.Interfaces.Repositories;

namespace WeatherApi.HostedService;

public class TimerHostedService : IHostedService
{
    private const int CacheTime = 20;

    private readonly IServiceProvider _serviceProvider;

    public TimerHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
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
            IWeatherRepository weatherRepository =
                scope.ServiceProvider.GetRequiredService<IWeatherRepository>();

            await weatherRepository.DeleteByCacheDate(finishCacheDate);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
