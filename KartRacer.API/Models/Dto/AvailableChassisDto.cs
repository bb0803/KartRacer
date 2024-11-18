using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KartRacer.API.Models.Dto
{
    public class AvailableChassisDto
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string ChassisBrand { get; set; }
        public Int32? X_ClassId { get; set; }
        [Required]
        public Byte Aero { get; set; }
        [Required]
        public Byte Brakes { get; set; }
        [Required]
        public Byte Steering { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Cost { get; set; }
    }
}
