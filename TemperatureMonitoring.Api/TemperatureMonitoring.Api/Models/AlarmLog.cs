namespace TemperatureMonitoring.Domain
{
    public class AlarmLog
    {
        public int Id { get; set; }
        public decimal Temperature { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
