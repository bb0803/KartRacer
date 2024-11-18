using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.Data
{
    public class RaceGrid
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 RaceId { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        public Byte Position { get; set; }
        [Required]
        public Int16 StartingPoint { get; set; }
    }

}

