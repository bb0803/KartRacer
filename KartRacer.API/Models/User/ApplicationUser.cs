using Microsoft.AspNetCore.Identity;

namespace KartRacer.API.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
    }
}
