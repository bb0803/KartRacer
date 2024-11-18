using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Dto
{
    public class AvailableEngineDto
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string EngineBrand { get; set; }
        public Byte? Rating { get; set; }
        public Byte? Power { get; set; }
        public decimal? Cost { get; set; }
        public Int32? X_ClassId { get; set; }
    }
}
