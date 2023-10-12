namespace WeatherApi.Entities;

public sealed class WeatherCity
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public double Temperature { get; private set; }
    public double MinimumTemperature { get; private set; }
    public double MaximumTemperature { get; private set; }
    public decimal Latitude { get; private set; }
    public decimal Longitude { get; private set; }
    public DateTime CreationDate { get; private set; }

    public WeatherCity(string name, double temperature, double minimumTemperature, double maximumTemperature,
        decimal latitude, decimal longitude)
    {
        Name = name;
        Temperature = temperature;
        MinimumTemperature = minimumTemperature;
        MaximumTemperature = maximumTemperature;
        Latitude = latitude;
        Longitude = longitude;
        CreationDate = DateTime.Now;
    }
}
