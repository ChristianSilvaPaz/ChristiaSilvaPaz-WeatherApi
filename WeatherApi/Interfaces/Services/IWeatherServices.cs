using WeatherApi.DTO;
using WeatherApi.Entities;

namespace WeatherApi.Interfaces.Services;

public interface IWeatherServices
{
    Task<WeatherCityResponseDTO?> GetByNameAsync(string name);
}
