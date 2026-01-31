using TemperatureMonitoring.Domain;

namespace TemperatureMonitoring.Application
{
    public interface ITemperatureBroadcaster
    {
        Task BroadcastAsync(TemperatureReading reading);

    }
}
