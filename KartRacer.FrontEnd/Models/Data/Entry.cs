using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.Data
{
    public class Entry
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 EventId { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        public Int32 X_ClassId { get; set; }
    }

}

