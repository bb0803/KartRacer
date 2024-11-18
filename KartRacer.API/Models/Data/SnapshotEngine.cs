using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class SnapshotEngine
    {
        [Required]
        public Int32 Id { get; set; }
        public Byte? Rating { get; set; }
    }

}

