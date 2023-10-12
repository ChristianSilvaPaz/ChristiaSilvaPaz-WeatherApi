using WeatherApi.Entities;

namespace WeatherApi.AntiCorruption;

public interface IWeatherApi
{
    Task<WeatherCity?> GetByNameAsync(string name);
}
