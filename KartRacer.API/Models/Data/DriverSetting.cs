using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class DriverSetting
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        public Int32? SessionId { get; set; }
        [Required]
        public Byte DriverMentality { get; set; }
        [Required]
        public Byte BrakingMentality { get; set; }
        public Int32? TyreId { get; set; }
    }

}

