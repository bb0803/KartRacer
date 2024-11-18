using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.Data
{
    public class SessionLapTime
    {
        [Required]
        public Int32 Id { get; set; }
        [MaxLength(20)]
        public string? SessionType { get; set; } = string.Empty;
        [Required]
        public Int32 SessionId { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        public Int16 Lap { get; set; }
        public decimal? LapTimeSeconds { get; set; }
        [MaxLength(500)]
        public string? Note { get; set; } = string.Empty;
        public decimal? TyreStatus { get; set; }
        public Int32? TyreTemp { get; set; }
        public Byte? BrakingMentality { get; set; }
        public Byte? SpeedMentality { get; set; }
    }

}

