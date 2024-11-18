using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.Dto
{
    public class EntriesDto
    {
        [Key] public int Id { get; set; }
        public string EventName { get; set; }
        public int? ClubId { get; set; }
        public string ClubName { get; set; }
        public DateTime StartDate { get; set; }
        public string Countdown { get; set; }
        public string EventStatus { get; set; }

    }
}
