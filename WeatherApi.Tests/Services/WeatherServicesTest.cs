using AutoMapper;
using NSubstitute;
using WeatherApi.AntiCorruption;
using WeatherApi.Entities;
using WeatherApi.Interfaces.Repositories;
using WeatherApi.Mappings;
using WeatherApi.Services;

namespace WeatherApi.Tests.Services;

public class WeatherServicesTest
{
    private readonly WeatherServices _weatherServices;
    private readonly IWeatherRepository _weatherRepository = Substitute.For<IWeatherRepository>();
    private readonly IWeatherApi _weatherApi = Substitute.For<IWeatherApi>();
    private readonly IMapper _mapper;

    public WeatherServicesTest()
    {
        var mockMapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new DomainToDTOMappingProfile());
        });

        _mapper = mockMapper.CreateMapper();

        _weatherServices = new WeatherServices(_weatherRepository, _weatherApi, _mapper);
    }

    [Fact]
    public async Task GetByName_ShouldReturnFromDataBase_WhenItIsCached()
    {
        //Arrange
        Random rand = new Random();

        string name = "Paracatu";
        double temperature = rand.NextDouble();
        double minimumTemperature = rand.NextDouble();
        double maximumTemperature = rand.NextDouble();
        decimal latitude = (decimal)rand.NextDouble();
        decimal longitude = (decimal)rand.NextDouble();

        var entity = new WeatherCity(
            name,
            temperature,
            minimumTemperature,
            maximumTemperature,
            latitude,
            longitude);

        _weatherRepository.GetByNameAsync(Arg.Any<string>(), Arg.Any<DateTime>()).Returns(entity);

        //Act
        var result = await _weatherServices.GetByNameAsync(name);

        //Assert
        Assert.Equal(result!.Name, name);
        Assert.Equal(result.Temperature, temperature);
        Assert.Equal(result.MinimumTemperature, minimumTemperature);
        Assert.Equal(result.MaximumTemperature, maximumTemperature);
        Assert.Equal(result.Latitude, latitude);
        Assert.Equal(result.Longitude, longitude);
    }

    [Fact]
    public async Task GetByName_ShouldReturnFromApi_WhenItIsDoesNotCached()
    {
        //Arrange
        Random rand = new Random();

        string name = "Paracatu";
        double temperature = rand.NextDouble();
        double minimumTemperature = rand.NextDouble();
        double maximumTemperature = rand.NextDouble();
        decimal latitude = (decimal)rand.NextDouble();
        decimal longitude = (decimal)rand.NextDouble();

        var entity = new WeatherCity(
            name,
            temperature,
            minimumTemperature,
            maximumTemperature,
            latitude,
            longitude);

        _weatherApi.GetByNameAsync(Arg.Any<string>()).Returns(entity);

        //Act
        var result = await _weatherServices.GetByNameAsync(name);

        //Assert
        Assert.Equal(result!.Name, name);
        Assert.Equal(result.Temperature, temperature);
        Assert.Equal(result.MinimumTemperature, minimumTemperature);
        Assert.Equal(result.MaximumTemperature, maximumTemperature);
        Assert.Equal(result.Latitude, latitude);
        Assert.Equal(result.Longitude, longitude);
    }

    [Fact]
    public async Task GetByName_ShouldReturnNull_WhenItIsDoesNotExistInCacheOrApi()
    {
        //Arrange
        string name = "Paracatu";

        //Act
        var result = await _weatherServices.GetByNameAsync(name);

        //Assert
        Assert.Null(result);
    }
}
