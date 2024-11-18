using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class Event
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public Byte Status { get; set; }
        public DateTime StartDate { get; set; }
        public Int32? ClubId { get; set; }
        public Int32? X_EventId { get; set; }
        public Int32? X_RegionId { get; set; }
        public Int32? X_SeriesId { get; set; }
    }

}

