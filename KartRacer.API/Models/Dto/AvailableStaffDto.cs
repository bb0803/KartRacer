using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KartRacer.API.Models.Dto
{
    public class AvailableStaffDto
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string StaffName { get; set; }
        public string StaffType { get; set; }
        [Required]
        public Byte Rating { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal? Salary { get; set; }
    }
}
