using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.Data
{
    public class Engine
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        [MaxLength(50)]
        public string EngineBrand { get; set; }
        [Required]
        [MaxLength(50)]
        public string EngineName { get; set; }
        public Byte? Rating { get; set; }
        public Byte? Power { get; set; }
        public Byte? Status { get; set; }
        public decimal? Cost { get; set; }
        public Int32? ChassisId { get; set; }
        [Required]
        public Int32 X_EngineId { get; set; }
        public Int32? X_ClassId { get; set; }
    }

}

