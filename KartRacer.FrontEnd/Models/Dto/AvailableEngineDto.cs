using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KartRacer.FrontEnd.Web.Models.Dto
{
    public class AvailableEngineDto
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string EngineName { get; set; }
        public Byte? Rating { get; set; }
        public Byte? Power { get; set; }
        public decimal? Cost { get; set; }
        public decimal? AdditionalEngineCost { get; set; }
        public Int32? X_ClassId { get; set; }
    }
}
