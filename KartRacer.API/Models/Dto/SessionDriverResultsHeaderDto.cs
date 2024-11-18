namespace KartRacer.API.Models.Dto
{
    public class SessionDriverResultsHeaderDto
    {
        public Int32 DriverId { get; set; }
        public string DriverName { get; set; }
		public Int16 Laps { get; set; }
        public decimal FastestLap { get; set; }
		public Int16 Position { get; set; }
        public Int16 PositionTotal { get; set; }
		public Int16 FastestLapNumber { get; set; }
    }
}
