using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.Data
{
    public class SeriesCalendar
    {
        [Required]
        public Int32 Id { get; set; }
        public Int32? SeriesId { get; set; }
        public Byte? Round { get; set; }


        [MaxLength(50)]
        public string? DateDescription { get; set; } = string.Empty;

        public Int32? X_SeriesId { get; set; }
        public Int32? X_CalendarId { get; set; }
    }

}

