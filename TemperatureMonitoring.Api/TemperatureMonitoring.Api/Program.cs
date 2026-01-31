using Microsoft.EntityFrameworkCore;
using TemperatureMonitoring.Application;
using TemperatureMonitoring.Hubs;
using TemperatureMonitoring.Infrastructure;
using TemperatureMonitoring.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TemperatureDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddSignalR();

builder.Services.AddSingleton<ITemperatureBroadcaster, SignalRTemperatureBroadcaster>();

builder.Services.AddScoped<TemperatureAlarmService>();

builder.Services.AddHostedService<TemperatureMonitorService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<TemperatureHub>("/temperatureHub");

app.Run();
