using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class Setup
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Byte FrontWidth { get; set; }
        [Required]
        public Int16 Camber { get; set; }
        [Required]
        public Int16 Caster { get; set; }
        [Required]
        public Int16 Toe { get; set; }
        [Required]
        public Int16 RearWidth { get; set; }
        [Required]
        public Byte RearAxle { get; set; }
        [Required]
        public Byte FrontSprocket { get; set; }
        [Required]
        public Byte RearSprocket { get; set; }
        [Required]
        public Byte TyrePressure { get; set; }
    }

}

