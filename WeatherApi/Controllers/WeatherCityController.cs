using Microsoft.AspNetCore.Mvc;
using WeatherApi.DTO;
using WeatherApi.Interfaces.Services;

namespace WeatherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherCityController : ControllerBase
    {
        private readonly IWeatherServices _weatherServices;

        public WeatherCityController(IWeatherServices weatherServices)
        {
            _weatherServices = weatherServices;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult<WeatherCityResponseDTO>> GetByNameAsync(string name)
        {
            if (string.IsNullOrEmpty(name)) 
                return BadRequest("Nome da cidade é obrigatório");

            var weatherCity = await _weatherServices.GetByNameAsync(name);
            
            return weatherCity is not null ? Ok(weatherCity) : BadRequest("Cidade não encontrada");
        }
    }
}
