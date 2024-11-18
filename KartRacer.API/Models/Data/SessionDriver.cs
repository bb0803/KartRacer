using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class SessionDriver
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 SessionId { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
    }

}

