using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class Part
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public Int32 DriverId { get; set; }
        public Int32? ChassisId { get; set; }
        public Byte? Status { get; set; }
        public decimal? Value { get; set; }
        public Int32? X_PartTypeId { get; set; }
        public Int32? X_PartId { get; set; }
    }

}

