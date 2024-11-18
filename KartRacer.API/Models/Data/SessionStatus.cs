using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class SessionStatus
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
        public Byte SpeedAbility { get; set; }
        public Byte? Consistency { get; set; }
        public Byte? BrakingAbility { get; set; }
        public Byte? Cornering { get; set; }
        public Byte? Overtaking { get; set; }
        public Byte? Defending { get; set; }
        public Byte? Aero { get; set; }
        public Byte? CarBrakes { get; set; }
        public Byte? Steering { get; set; }
        [Required]
        public Int32 Lap { get; set; }
        public Byte? Segment { get; set; }
        public decimal? Metres { get; set; }
        public Byte? Position { get; set; }
        public TimeOnly? TotalTime { get; set; }
        public TimeOnly? LapTime { get; set; }
        [Required]
        public decimal CurrentSpeed { get; set; }
        public Int32? TyreId { get; set; }
        [Required]
        public decimal TyreStatus { get; set; }
        public Int16? TyreLapsOld { get; set; }
        public decimal? Fuel { get; set; }
        [Required]
        public Byte BrakePads { get; set; }
        [Required]
        public Int32 TyreTemp { get; set; }
        public Int16? BrakingMentality { get; set; }
        public Int16? DriverMentality { get; set; }
        public decimal? TyreSpeedFactor { get; set; }
        public decimal? TyreDegradationFactor { get; set; }
        public Byte? EnginePower { get; set; }
        public Byte? EngineStatus { get; set; }
    }

}

