using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class SetupFavourite
    {
        public Int32 Id { get; set; }
        public int DriverId { get; set; }
        public int SetupId { get; set; }
        public string? Name { get; set; } = string.Empty;
        
    }

}

