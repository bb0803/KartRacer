namespace KartRacer.FrontEnd.Services.TokenProvider
{
    public interface ITokenProvider
    {
        void SetToken(string token);
        Task<string?> GetToken();
        Task ClearToken();
    }
}
