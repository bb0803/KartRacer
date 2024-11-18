using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Models.Data
{
    public class UserSetting
    {
        [Key]
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        public int? DriverId { get; set; }
        [MaxLength(50)]
        public string? NickName { get; set; } = string.Empty;
        public Int32? CurrentSessionId { get; set; }
    }

}

