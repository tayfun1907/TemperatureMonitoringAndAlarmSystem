using Microsoft.EntityFrameworkCore;
using TemperatureMonitoring.Domain;

namespace TemperatureMonitoring.Infrastructure
{
    public class TemperatureDbContext : DbContext
    {
        public TemperatureDbContext(DbContextOptions<TemperatureDbContext> options)
            : base(options)
        {
        }

        public DbSet<AlarmLog> AlarmLogs => Set<AlarmLog>();
    }
}
