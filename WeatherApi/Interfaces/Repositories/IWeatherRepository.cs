using WeatherApi.DTO;
using WeatherApi.Entities;

namespace WeatherApi.Interfaces.Repositories;

public interface IWeatherRepository
{
    Task<WeatherCity?> GetByNameAsync(string name, DateTime startCreationDate);
    Task<WeatherCity> CreateAsync(WeatherCity weatherCity);
    Task DeleteByCacheDateAsync(DateTime cacheDate);
}

