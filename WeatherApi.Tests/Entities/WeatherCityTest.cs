using WeatherApi.Entities;

namespace WeatherApi.Tests.Entities;

public class WeatherCityTest
{
    [Fact]
    public async Task WeatherCity_ShouldReturnObjectWeatherCity()
    {
        //Arrange
        Random rand = new Random();

        string name = "Paracatu";
        double temperature = rand.NextDouble();
        double minimumTemperature = rand.NextDouble();
        double maximumTemperature = rand.NextDouble();
        decimal latitude = (decimal)rand.NextDouble();
        decimal longitude = (decimal)rand.NextDouble();

        //Act
        var entity = new WeatherCity(
            name,
            temperature,
            minimumTemperature,
            maximumTemperature,
            latitude,
            longitude);

        //Assert
        Assert.True(entity.Id == 0);
        Assert.Equal(entity.Name, name);
        Assert.Equal(entity.Temperature, temperature);
        Assert.Equal(entity.MinimumTemperature, minimumTemperature);
        Assert.Equal(entity.MaximumTemperature, maximumTemperature);
        Assert.Equal(entity.Latitude, latitude);
        Assert.Equal(entity.Longitude, longitude);
        Assert.NotEqual(entity.CreationDate, DateTime.Now);
    }
}
