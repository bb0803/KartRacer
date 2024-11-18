using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Web.Models.Dto
{
    public class ChangeTyreDto
    {
        [Required]
        public Int32 DriverId { get; set; }
        public Int32 TyreId { get; set; }
    }
}
