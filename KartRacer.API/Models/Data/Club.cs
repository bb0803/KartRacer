using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class Club
    {
        [Required]
        public Int32 Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Region { get; set; }
    }

}

