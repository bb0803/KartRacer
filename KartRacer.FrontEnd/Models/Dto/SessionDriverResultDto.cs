using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Web.Models.Dto
{
    public class SessionDriverResultDto
    {
        public int DriverId { get; set; }
        public short Lap {  get; set; }
        public decimal LapTimeSeconds { get; set; }
        public int X_TyreId { get; set; }
        public decimal TyreStatus { get; set; }
    }
}
