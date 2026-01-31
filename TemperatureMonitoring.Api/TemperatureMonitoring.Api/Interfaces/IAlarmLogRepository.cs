using TemperatureMonitoring.Domain;

namespace TemperatureMonitoring.Application
{
    public interface IAlarmLogRepository
    {
        Task AddAsync(AlarmLog alarmLog);
    }
}
