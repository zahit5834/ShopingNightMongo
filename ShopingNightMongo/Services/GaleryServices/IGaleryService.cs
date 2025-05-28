using ShopingNightMongo.Dtos.GaleryDtos;

namespace ShopingNightMongo.Services.GaleryServices
{
    public interface IGaleryService
    {
        Task<List<ResultGaleryDto>> GetAllGaleryAsync();
        Task CreateGaleryAsync(CreateGaleryDto createGaleryDto);
        Task UpdateGaleryAsync(UpdateGaleryDto updateGaleryDto);
        Task DeleteGaleryAsync(string galeryId);
        Task<GetGaleryDto> GetGaleryByIdAsync(string galeryId);
    }
}
