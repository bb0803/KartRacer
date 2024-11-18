using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class Driver
    {
        [Required]
        public Int32 Id { get; set; }
        [MaxLength(100)]
        public string? DriverName { get; set; } = string.Empty;
        [Required]
        public Byte Speed { get; set; }
        [Required]
        public Byte Consistency { get; set; }
        public Byte? Braking { get; set; }
        public Byte? Cornering { get; set; }
        public Byte? Overtaking { get; set; }
        public Byte? Defending { get; set; }
        public Byte? Experience { get; set; }
        public int? CurrentKartId { get; set; }
        public int? CurrentEngineId { get; set; }
        public int? CurrentSetupId { get; set; }
        public Int32? X_ClassId { get; set; }
    }

}

