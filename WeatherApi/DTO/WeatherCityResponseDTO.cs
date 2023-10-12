using System.ComponentModel;

namespace WeatherApi.DTO;

public class WeatherCityResponseDTO
{
    public string? Name { get; set; }
    public double Temperature { get; set; }
    public double MinimumTemperature { get; set; }
    public double MaximumTemperature { get; set; }
    public decimal Latitude { get; set; }
    public decimal Longitude { get; set; }
}
