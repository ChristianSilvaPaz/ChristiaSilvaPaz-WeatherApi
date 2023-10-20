using WeatherApi.Interfaces.Repositories;

namespace WeatherApi.HostedService;

public class TimerHostedService : BackgroundService
{
    private const int CacheTime = 20;
    private readonly IServiceProvider _serviceProvider;

    public TimerHostedService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await ExecuteProcess(cancellationToken);
    }

    private async Task ExecuteProcess(CancellationToken cancellationToken)
    {
        var finishCacheDate = DateTime.Now.AddMinutes(-CacheTime);

        using (IServiceScope scope = _serviceProvider.CreateScope())
        {
            IWeatherRepository weatherRepository =
                scope.ServiceProvider.GetRequiredService<IWeatherRepository>();

            while (!cancellationToken.IsCancellationRequested)
            {
                await weatherRepository.DeleteByCacheDateAsync(finishCacheDate);
                await Task.Delay(5000, cancellationToken);
            }
        }
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await base.StopAsync(cancellationToken);
    }
}
