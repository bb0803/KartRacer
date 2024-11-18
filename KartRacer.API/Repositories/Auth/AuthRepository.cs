
using KartRacer.API.Data;
using KartRacer.API.Models.Data;
using KartRacer.API.Models.User;
using KartRacer.API.Repositories.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace KartRacer.API.Repositories.Auth
{
    public class AuthRepository : GenericRepository<Data.User>, IAuthRepository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DataContext context;

        public AuthRepository(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, DataContext context) : base(context)
        {
            this._userManager = userManager;
            this.context = context;
            this._httpContextAccessor = httpContextAccessor;
        }
        /*
         * Gets the row from user settings for the current user
         */
        public async Task<UserSetting> GetUserAsync()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Email).Value;
            return await context.UserSettings
                .FirstOrDefaultAsync(q => q.Username == userId);
        }
    }
}
