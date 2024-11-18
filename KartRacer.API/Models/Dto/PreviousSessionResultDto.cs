namespace KartRacer.API.Models.Dto
{
    public class PreviousSessionResultDto
    {
        public int DriverId { get; init; }
        public string DriverName { get; init; } = string.Empty;
        public string Compound {  get; init; } = string.Empty;
        public decimal? MinLapTime { get; init; }
        public decimal? AvgLapTime { get; init; }
        public decimal? SessionMinLapTime { get; init; }
        public decimal? SessionAvgLapTime { get; init; }
    }
}
