using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class SnapshotDriver
    {
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        public Byte Speed { get; set; }
        [Required]
        public Byte Consistency { get; set; }
        public Byte? Braking { get; set; }
        public Byte? Cornering { get; set; }
        public Byte? Overtaking { get; set; }
        public Byte? Defending { get; set; }
        public Byte? Experience { get; set; }
    }

}

