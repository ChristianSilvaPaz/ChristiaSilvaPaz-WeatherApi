using AutoMapper;
using WeatherApi.DTO;
using WeatherApi.Entities;

namespace WeatherApi.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile()
    {
        CreateMap<WeatherCity, WeatherCityResponseDTO>().ReverseMap();
    }
}
