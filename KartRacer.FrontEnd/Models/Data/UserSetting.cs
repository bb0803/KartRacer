using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.Data
{
    public class UserSetting
    {
        [Required]
        [MaxLength(100)]
        public string Username { get; set; }
        [MaxLength(50)]
        public string? NickName { get; set; } = string.Empty;
        public int? DriverId { get; set; }
        public Int32? CurrentSessionId { get; set; }
    }

}

