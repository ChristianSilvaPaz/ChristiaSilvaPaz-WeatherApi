using AutoMapper;
using WeatherApi.AntiCorruption;
using WeatherApi.DTO;
using WeatherApi.Interfaces.Repositories;
using WeatherApi.Interfaces.Services;

namespace WeatherApi.Services;

public class WeatherServices : IWeatherServices
{
    private const int CacheTime = 20;

    private readonly IWeatherRepository _weatherRepository;
    private readonly IWeatherApi _weatherApi;
    private readonly IMapper _mapper;

    public WeatherServices(IWeatherRepository weatherRepository, IWeatherApi weatherApi, IMapper mapper)
    {
        _weatherRepository = weatherRepository;
        _weatherApi = weatherApi;
        _mapper = mapper;
    }

    public async Task<WeatherCityResponseDTO?> GetByNameAsync(string name)
    {
        var startCacheDate = DateTime.Now.AddMinutes(-CacheTime);

        var weatherFromDb = await _weatherRepository.GetByNameAsync(name, startCacheDate);

        if (weatherFromDb is not null) 
            return _mapper.Map<WeatherCityResponseDTO>(weatherFromDb);

        var weatherFromApi = await _weatherApi.GetByNameAsync(name);

        if (weatherFromApi is null)
            return null;

        await _weatherRepository.CreateAsync(weatherFromApi);

        return _mapper.Map<WeatherCityResponseDTO>(weatherFromApi);
    }
}
