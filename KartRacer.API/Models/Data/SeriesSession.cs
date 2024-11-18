using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class SeriesSession
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 SeriesId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [MaxLength(20)]
        public string SessionType { get; set; }
        [MaxLength(50)]
        public string? SessionTitle { get; set; } = string.Empty;
        public Int32? SessionId { get; set; }
        public Int16? Minutes { get; set; }
        public Int16? Laps { get; set; }

        [Required]
        public Int16 Sequence { get; set; }
        [Required]
        public Int32 X_CalendarId { get; set; }
    }

}

