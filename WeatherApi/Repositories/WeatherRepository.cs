using Dapper;
using MySqlConnector;
using WeatherApi.Entities;
using WeatherApi.Interfaces.Repositories;

namespace WeatherApi.Repositories;

public class WeatherRepository : IWeatherRepository
{
    private readonly string _connectionString;

    public WeatherRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public async Task<WeatherCity?> GetByNameAsync(string name, DateTime startCreationDate)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            const string sql = "SELECT * FROM WeatherCities WHERE Name = @Name AND CreationDate >= @Date";

            var result = await connection.QueryFirstOrDefaultAsync(sql, new { Name = name, Date = startCreationDate });

            if (result is not null)
            {
                return new WeatherCity(
                    result.Name,
                    result.Temperature,
                    result.MinimumTemperature,
                    result.MaximumTemperature,
                    result.Latitude,
                    result.Longitude);
            }

            return null;
        }
    }

    public async Task<WeatherCity> CreateAsync(WeatherCity weatherCity)
    {
        var parameters = new
        {
            weatherCity.Name,
            weatherCity.Temperature,
            weatherCity.MinimumTemperature,
            weatherCity.MaximumTemperature,
            weatherCity.Latitude,
            weatherCity.Longitude,
            weatherCity.CreationDate
        };

        using (var connection = new MySqlConnection(_connectionString))
        {
            const string sql = @"
            INSERT INTO WeatherCities (
			            Name,
			            Temperature,
			            MinimumTemperature,
			            MaximumTemperature,
			            Latitude,
			            Longitude,
			            CreationDate)
                    VALUES (
			            @Name,
			            @Temperature,
			            @MinimumTemperature,
			            @MaximumTemperature,
			            @Latitude,
			            @Longitude,
			            @CreationDate)";

            await connection.ExecuteAsync(sql, parameters);

            return weatherCity;
        }
    }

    public async Task DeleteByCacheDate(DateTime cacheDate)
    {
        using (var connection = new MySqlConnection(_connectionString))
        {
            const string sql = "DELETE FROM WeatherCities WHERE CreationDate <= @Date";

            await connection.ExecuteAsync(sql, new { Date = cacheDate });
        }
    }
}


