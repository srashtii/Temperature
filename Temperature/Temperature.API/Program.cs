
using Microsoft.EntityFrameworkCore;
using Temperature.API.Interfaces;
using Temperature.API.Services;
using TemperatureData;
using TemperatureInfrastructure;
using TemperatureSensor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TemperatureContext>(op =>
op.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
.EnableSensitiveDataLogging());
builder.Services.AddScoped<ITemperatureSensorService, DefaultTemperatureSensorService>();
//builder.Services.AddScoped<ITemperatureRepository, DefaultTemperatureRepository>();
//builder.Services.AddScoped<ISensorLimitRepository, DefaultSensorLimitRepository>();
builder.Services.AddScoped<ITemperatureSensorComponent, DefaultTemperatureSensorComponentService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
