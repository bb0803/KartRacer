namespace KartRacer.FrontEnd.Models.Dto
{
    public class SessionHistoryDto
    {
        public string EventName { get; init; } = String.Empty;  
        public DateOnly EventStartDate {  get; init; }
        public DateOnly SessionStartDate { get; init; }
        public int SessionId { get; init; }
        public string SessionName { get; init; } = String.Empty;
        public decimal BestLapTime { get; init; }
        public string CircuitName { get; init; } = String.Empty;
        public Byte Position { get; init; }
        public string SetupShort {  get; init; } = String.Empty;
        public string Setup {  get; init; } = String.Empty;

    }
}
