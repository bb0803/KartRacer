using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Dto
{
    public class DriverSettingsDto
    {
        [Required]
        public Int32 Id { get; set; }
        public Int32 DriverId { get; set; }
        public Byte DriverMentality { get; set; }
        public Byte BrakingMentality { get; set; }
        public Byte FrontDownforce { get; set; }
        public Byte RearDownforce { get; set; }
        public Byte DriverAbility { get; set; }
        public Byte BrakingAbility { get; set; }
    }
}
