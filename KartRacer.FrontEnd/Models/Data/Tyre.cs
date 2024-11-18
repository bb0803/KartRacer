using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.Data
{
    public class Tyre
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        public decimal TyreStatus { get; set; }
        [Required]
        public Int32 X_TyreId { get; set; }
    }

}

