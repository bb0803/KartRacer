using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class Series
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 WorldId { get; set; }
        public Int32? SeriesCalendarId { get; set; }

        [Required]
        public Int32 X_SeriesId { get; set; }
        public Int32? X_ClassId { get; set; }
    }

}

