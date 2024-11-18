using System.ComponentModel.DataAnnotations;

namespace KartRacer.API.Data
{
    public class UserCustom
    {
        [Required, EmailAddress, Key]
        public string UserId { get; set; } = string.Empty;
        [Required]
        public int TenantId { get; set; }
    }
}
