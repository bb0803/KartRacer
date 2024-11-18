using Blazored.LocalStorage;
using System.IdentityModel.Tokens.Jwt;


namespace KartRacer.FrontEnd.Services.TokenProvider
{
    public class TokenProvider: ITokenProvider
    {
        private readonly ILocalStorageService localStorage;
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;
        public TokenProvider(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
            jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        }


        public async Task ClearToken()
        {
            await localStorage.RemoveItemAsync("KartRacer_accessToken");
        }

        public async Task<string> GetToken()
        {
            var savedToken1 = await localStorage.GetItemAsync<string>("KartRacer_accessToken");
            if (savedToken1 == null) { return null; }
            //var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(savedToken1);
            return savedToken1.ToString();
        }

        public void SetToken(string token)
        {
            localStorage.SetItemAsync<string>("KartRacer_accessToken", token);

        }
    }
}
