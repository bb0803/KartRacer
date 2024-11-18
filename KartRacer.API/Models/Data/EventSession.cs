using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class EventSession
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 EventId { get; set; }
        [Required]
        public Int32 X_SessionId { get; set; }
        public DateTime? SessionDate { get; set; }
        public Boolean? Completed { get; set; }
    }
}
