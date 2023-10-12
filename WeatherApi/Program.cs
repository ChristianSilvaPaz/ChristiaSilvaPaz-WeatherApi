using WeatherApi.AntiCorruption;
using WeatherApi.HostedService;
using WeatherApi.Integration;
using WeatherApi.Interfaces.Repositories;
using WeatherApi.Interfaces.Services;
using WeatherApi.Mappings;
using WeatherApi.Repositories;
using WeatherApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHostedService<TimerHostedService>();

builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

builder.Services.AddScoped<IWeatherServices, WeatherServices>();
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
builder.Services.AddScoped<IWeatherApi, OpenWeatherApi>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
