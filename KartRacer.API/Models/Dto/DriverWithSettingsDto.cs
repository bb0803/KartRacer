using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Dto
{
    public class DriverWithSettingsDto
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
        public decimal? Salary { get; set; }
        public Byte? DriverMentality { get; set; }
        public Byte? BrakingMentality { get; set; }
        public Byte? FrontDownforce { get; set; }
        public Byte? RearDownforce { get; set; }
    }
}
