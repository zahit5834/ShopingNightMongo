using Microsoft.AspNetCore.Mvc;
using ShopingNightMongo.Services.CategoryServices;
using System.Threading.Tasks;

namespace ShopingNightMongo.ViewComponents
{
    public class _DefaultCategoriesComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DefaultCategoriesComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }

}

