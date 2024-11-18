using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.Data
{
    public class SessionSplit
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        public Int32 SessionId { get; set; }
        [Required]
        public Int32 DriverId { get; set; }
        [Required]
        public Int16 Lap { get; set; }
        [Required]
        public Byte SegmentNo { get; set; }
        [Required]
        public decimal SplitTime { get; set; }
        public decimal? BrakeTime { get; set; }
    }

}

