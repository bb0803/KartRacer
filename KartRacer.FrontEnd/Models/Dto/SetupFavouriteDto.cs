using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.Dto
{
    public class SetupFavouriteDto
    {
        public Int32 Id { get; set; }
        public int DriverId { get; set; }
        public int SetupId { get; set; }
        public string? SetupName { get; set; } = string.Empty;
        public string? SetupDetailsShort { get; set; } = string.Empty;
        public string? SetupDetails { get; set; } = string.Empty;
    }

}

