using KartRacer.FrontEnd.Models.API;
using KartRacer.FrontEnd.Models.Data;
using KartRacer.FrontEnd.Models.Dto;
using KartRacer.FrontEnd.Services.Base;

namespace KartRacer.FrontEnd.Services.Setup
{
    public class SetupService : ISetupService
    {
        private readonly IBaseService _baseService;
        private readonly string APIHostAddress = "https://localhost:7149";
        public SetupService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDto?> ChangeAxleAsync(int Axle)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Put",
                Data = Axle,
                Url = APIHostAddress + "/api/setup/axle"
            });
        }

        public async Task<ResponseDto?> ChangeChassisAsync(int Chassis)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Put",
                Data = Chassis,
                Url = APIHostAddress + "/api/setup/chassis"
            });
        }

        public async Task<ResponseDto?> ChangeCurrentSetupAsync(Models.Data.Setup setup)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Put",
                Data = setup,
                Url = APIHostAddress + "/api/setup/current"
            });
        }

        public async Task<ResponseDto?> ChangeTyreAsync(int Tyre)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Put",
                Data = Tyre,
                Url = APIHostAddress + "/api/setup/changeTyre"
            });
        }

        //public async Task<ResponseDto?> LoadSetupAsync()
        //{
        //    return await _baseService.SendAsync(new RequestDto()
        //    {
        //        ApiType = "Get",
        //        Url = APIHostAddress + "/api/setup/load"
        //    });
        //}

        public async Task<ResponseDto?> SaveSetupAsync(Models.Data.Setup setup)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Put",
                Data = setup,
                Url = APIHostAddress + "/api/setup/save"
            });
        }

        public async Task<ResponseDto> GetSetupFavoritesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/setup/favourites"
            });
        }

        public async Task<ResponseDto> LoadSetupFavouriteAsync(int setupId)
        {
            SingleIntDto setup = new SingleIntDto() { Id = setupId };
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Put",
                Data = setup,
                Url = APIHostAddress + "/api/setup/favourites/load"
            });
        }

        public async Task<ResponseDto> SaveSetupFavouriteAsync(SetupFavourite setupFavourite)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Post",
                Data = setupFavourite,
                Url = APIHostAddress + "/api/setup/favourites/save"
            });
        }

        public async Task<ResponseDto> SetupExistsAsync(Models.Data.Setup setup)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Data = setup,
                Url = APIHostAddress + "/api/setup/exists"
            });
        }

        public async Task<ResponseDto> GetSetupAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/setup"
            });
        }

        public async Task<ResponseDto?> GetAllSetupAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = "Get",
                Url = APIHostAddress + "/api/setup/all"
            });
        }
    }
}
