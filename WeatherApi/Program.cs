using Data;
using Data.Interface;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//var connectionString = builder.Configuration.GetConnectionString("LocalContext");
builder.Services.AddDbContext<WeatherContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalContext")));

// services
builder.Services.AddScoped<IGeoPlaceRepository, GeoPlaceRepository>();
builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

builder.Services.AddScoped<IGeoPlaceService, GeoPlaceService>();
builder.Services.AddScoped<IWeatherForecastService, WeatherForecastService>();
builder.Services.AddAutoMapper(typeof(WeatherProfile));

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
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

