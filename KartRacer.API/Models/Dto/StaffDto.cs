using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Dto
{
    public class StaffDto
    {
        [Required]
        public Int32 Id { get; set; }
        [MaxLength(100)]
        public string? StaffName { get; set; } = string.Empty;
        [Required]
        public string? StaffType { get; set; } = string.Empty;
        public Byte? Rating { get; set; }
        public decimal? Salary { get; set; }
        
    }
}
