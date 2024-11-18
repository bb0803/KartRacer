namespace KartRacer.FrontEnd.Models.Dto
{
    public class EntrySessionsDto
    {
        public int EventSessionId { get; set; }
        public int EventId { get; set; }
        public string EventInfo { get; set; } = String.Empty;
        public int ClubId { get; set; }
        public string ClubName { get; set; } = String.Empty;
        public DateOnly EventStartDate { get; set; }
        public string EventCountdown { get; set; } = String.Empty;
        public string SessionCountdown { get; set; } = String.Empty;
        public string EventStatus { get; set; } = String.Empty;
        public DateOnly SessionDate { get; set; }
        public string SessionType { get; set; } = String.Empty;
        public string SessionName { get; set; } = String.Empty;
        public int? SetupId { get; set; }
    }
}
