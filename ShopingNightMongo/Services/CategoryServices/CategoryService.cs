using ShopingNightMongo.Dtos.CategoryDtos;

namespace ShopingNightMongo.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        Task ICategoryService.CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            throw new NotImplementedException();
        }

        Task ICategoryService.DeleteCategoryAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task<List<ResultCategoryDto>> ICategoryService.GetAllCategories()
        {
            throw new NotImplementedException();
        }

        Task<GetCategoryDto> ICategoryService.GetCategoryByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task ICategoryService.UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            throw new NotImplementedException();
        }
    }
}
