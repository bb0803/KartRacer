using KartRacer.FrontEnd.Models.API;

namespace KartRacer.FrontEnd.Services.Base
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
        
    }
}
