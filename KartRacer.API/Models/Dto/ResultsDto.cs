namespace KartRacer.API.Models.Dto
{
    public class ResultsDto
    {
        public int DriverId { get; init; }
        public string DriverName { get; init; } = string.Empty;
        public byte Position { get; init; }
        public byte Laps {  get; init; }
        public TimeOnly TotalTime { get; init; }
        public decimal? FastestLap { get; init; }
        public decimal? LastLap { get; init; }
        public decimal? LastLapDifference { get; init; }
        public decimal? DifferenceToFirst { get; init; }
        public decimal? DifferenceToFastestLap { get; init; }
        public decimal? CoEfficient { get; init; }
        public byte? TyreStatus { get; init; }
        public byte? TyreLapsOld { get; init; }

    }
}
