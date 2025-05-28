using ShopingNightMongo.Dtos.ProductImageDtos;

namespace ShopingNightMongo.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task CreateProductImage(CreateProductImageDto createProductImageDto);
        Task UpdateProductImage(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImage(string id);
        Task<GetProductImageDto> GetProductImageByIdAsync(string id);

    }
}
