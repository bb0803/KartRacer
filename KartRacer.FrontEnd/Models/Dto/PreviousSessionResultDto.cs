namespace KartRacer.FrontEnd.Web.Models.Dto
{
    public class PreviousSessionResultDto
    {
        public int DriverId { get; set; }
        public string DriverName { get; set; } = string.Empty;
        public Int16 Laps { get; set; }
        public string Compound {  get; set; } = string.Empty;
        public decimal MinLapTime { get; set; }
        public decimal AvgLapTime { get; set; }
        public decimal SessionMinLapTime { get; set; }
        public decimal SessionAvgLapTime { get; set; }
        public Int16 DriverPosition { get; set; }
        public Int16 TotalDrivers { get; set; }
    }
}
