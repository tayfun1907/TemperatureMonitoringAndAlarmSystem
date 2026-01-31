using TemperatureMonitoring.Application;
using TemperatureMonitoring.Domain;

namespace TemperatureMonitoring.Services
{
    public class TemperatureMonitorService : BackgroundService
    {
        private readonly ITemperatureBroadcaster _broadcaster;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly Random _random = new();

        public TemperatureMonitorService(ITemperatureBroadcaster broadcaster, IServiceScopeFactory scopeFactory)
        {
            _broadcaster = broadcaster;
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var temp = _random.Next(20, 101);

                var reading = new TemperatureReading
                {
                    Value = temp,
                    Timestamp = DateTime.UtcNow
                };

                Console.WriteLine($"Temperature: {temp}°C");

                await _broadcaster.BroadcastAsync(reading);

                await _broadcaster.BroadcastAsync(reading);

                using (var scope = _scopeFactory.CreateScope())
                {
                    var alarmService = scope.ServiceProvider.GetRequiredService<TemperatureAlarmService>();

                    await alarmService.CheckAndLogAsync(temp);
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
