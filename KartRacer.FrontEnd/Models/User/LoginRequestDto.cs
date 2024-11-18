using System.ComponentModel.DataAnnotations;

namespace KartRacer.FrontEnd.Models.User
{
    public class LoginRequestDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
