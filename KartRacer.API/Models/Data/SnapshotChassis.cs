using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class SnapshotChassis
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Byte Aero { get; set; }
        [Required]
        public Byte Brakes { get; set; }
        [Required]
        public Byte Steering { get; set; }
    }

}

