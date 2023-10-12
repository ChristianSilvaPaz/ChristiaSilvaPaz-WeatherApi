using Newtonsoft.Json;
using WeatherApi.AntiCorruption;
using WeatherApi.Entities;

namespace WeatherApi.Integration;

public class OpenWeatherApi : IWeatherApi
{
    private readonly IHttpClientFactory _clientFactory;
    private readonly IConfiguration _configuration;

    public OpenWeatherApi(IHttpClientFactory clientFactory, IConfiguration configuration)
    {
        _clientFactory = clientFactory;
        _configuration = configuration;
    }

    public async Task<WeatherCity?> GetByNameAsync(string name)
    {
        var keyApi = _configuration.GetSection("OpenWeatherApi:Key").Value;
        var baseAddress = _configuration.GetSection("OpenWeatherApi:BaseAddress").Value!;

        var client = _clientFactory.CreateClient();
        client.BaseAddress = new Uri(baseAddress);

        var url = $"?q={name}&units=metric&appid={keyApi}";

        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            var dynamicObject = JsonConvert.DeserializeObject<dynamic>(stringResponse)!;

            return new WeatherCity(
                name,
                (double)dynamicObject.main.temp,
                (double)dynamicObject.main.temp_min,
                (double)dynamicObject.main.temp_max,
                (decimal)dynamicObject.coord.lat,
                (decimal)dynamicObject.coord.lon);
        }

        return null;
    }
}
