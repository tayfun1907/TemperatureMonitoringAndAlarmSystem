using Microsoft.AspNetCore.SignalR;
using TemperatureMonitoring.Application;
using TemperatureMonitoring.Domain;
using TemperatureMonitoring.Hubs;

namespace TemperatureMonitoring.Infrastructure
{
    public class SignalRTemperatureBroadcaster : ITemperatureBroadcaster
    {
        private readonly IHubContext<TemperatureHub> _hubContext;

        public SignalRTemperatureBroadcaster(IHubContext<TemperatureHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task BroadcastAsync(TemperatureReading reading)
        {
            await _hubContext.Clients.All
                .SendAsync("temperatureUpdated", reading);
        }

    }
}
