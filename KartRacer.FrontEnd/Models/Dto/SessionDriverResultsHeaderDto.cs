namespace KartRacer.FrontEnd.Web.Models.Dto
{
    public class SessionDriverResultsHeaderDto
    {
        public Int32 DriverId { get; set; }
        public string DriverName { get; set; }
		public Int16 Laps { get; set; }
        public decimal FastestLap { get; set; }
		public Int16 Position { get; set; }
        public Int16 PositionTotal { get; set; }
		public decimal? FastestLapSoft { get; set; }
		public Int16? PositionSoft { get; set; }
        public Int16? PositionSoftTotal { get; set; }
		public decimal? FastestLapMedium { get; set; }
		public Int16? PositionMedium { get; set; }
        public Int16? PositionMediumTotal { get; set; }
		public decimal? FastestLapHard { get; set; }
		public Int16? PositionHard { get; set; }
        public Int16? PositionHardTotal { get; set; }
		public Int16 FastestLapNumber { get; set; }
    }
}
