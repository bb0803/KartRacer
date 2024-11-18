using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using KartRacer.FrontEnd.Services.Base;
using KartRacer.FrontEnd.Services.TokenProvider;
using KartRacer.FrontEnd.Providers;
using KartRacer.FrontEnd.Models.API;
using KartRacer.FrontEnd.Models.User;
namespace KartRacer.FrontEnd.Services.Auth
{
    public class AuthService: IAuthService
    {
        private readonly IBaseService _baseService;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ITokenProvider _tokenProvider;
        private readonly string APIHostAddress = "https://localhost:7149";

        public AuthService(IBaseService baseService, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider, ITokenProvider tokenProvider)
        {
            _baseService = baseService;
            _localStorage = localStorage;
            this._authenticationStateProvider = authenticationStateProvider;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            try
            {
                ResponseDto response = await _baseService.SendAsync(new RequestDto()
                {
                    ApiType = "Post",
                    Data = loginRequestDto,
                    Url = APIHostAddress + "/api/Auth/login"
                }, withBearer: false);

                LoginResponsedto loginResponse = JsonConvert.DeserializeObject<LoginResponsedto>(response.Result.ToString()) as LoginResponsedto;
                //set Token
                _tokenProvider.SetToken(loginResponse.Token);
                //Change auth state of app
                await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedIn();
                return response;

            }
            catch (Exception ex)
            {
                ResponseDto failure = new ResponseDto();
                failure.Message = ex.Message;
                failure.IsSuccess = false;
                return failure;

            }
        }

        public async Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Post",
                Data = registrationRequestDto,
                Url = APIHostAddress + "/api/auth/register"
            }, withBearer: false);
        }

        public async Task<ResponseDto?> LogoutAsync()
        {
            try
            {
                ResponseDto response = new ResponseDto();
                //Clear token
                await _tokenProvider.ClearToken();

                //Change auth state of app
                await ((ApiAuthenticationStateProvider)_authenticationStateProvider).LoggedOut();

                response.IsSuccess = true;
                response.Message = "The user was logged out successfully.";

                return response;

            }
            catch (Exception ex)
            {
                ResponseDto failure = new ResponseDto();
                failure.Message = ex.Message;
                failure.IsSuccess = false;
                return failure;

            }
        }
    }
}
