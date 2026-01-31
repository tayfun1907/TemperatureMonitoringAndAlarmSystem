using TemperatureMonitoring.Domain;
using TemperatureMonitoring.Infrastructure;

namespace TemperatureMonitoring.Services
{
    public class TemperatureAlarmService
    {
        private readonly TemperatureDbContext _dbContext;

        public TemperatureAlarmService(TemperatureDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CheckAndLogAsync(double temperature)
        {
            if (temperature >= 80)
            {
                try
                {
                    var alarm = new AlarmLog
                    {
                        Temperature = (decimal)temperature,
                        CreatedAt = DateTime.UtcNow
                    };

                    _dbContext.AlarmLogs.Add(alarm);
                    await _dbContext.SaveChangesAsync();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[VERİTABANI HATASI] {DateTime.Now}: {ex.Message}");

                    _dbContext.ChangeTracker.Clear();
                }
            }
        }
    }
}
