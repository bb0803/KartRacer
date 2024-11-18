using KartRacer.API.Models.User;

namespace KartRacer.API.Services.JWTTokenGenerator
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
