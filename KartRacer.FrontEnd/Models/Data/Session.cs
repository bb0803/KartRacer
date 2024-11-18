using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.Data
{
    public class Session
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int16 Season { get; set; }
        public Int32? SeriesId { get; set; }
        public Byte? SessionSequence { get; set; }
        [Required]
        public Byte Round { get; set; }
        [MaxLength(20)]
        public string? SessionType { get; set; } = string.Empty;
        [Required]
        public Byte X_ClassId { get; set; }
        [Required]
        public Int32 X_CircuitId { get; set; }
        public Byte? Race { get; set; }
    }

}

