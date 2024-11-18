using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.Data
{
    public class Transaction
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        public Int32 ClassId { get; set; }
        [Required]
        public decimal Cost { get; set; }
        public DateTime? When { get; set; }
        [MaxLength(100)]
        public string? Notes { get; set; } = string.Empty;
    }

}

