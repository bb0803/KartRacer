using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.Data
{
    public class SnapshotEngine
    {
        [Required]
        public Int32 Id { get; set; }
        public Byte? Rating { get; set; }
    }

}

