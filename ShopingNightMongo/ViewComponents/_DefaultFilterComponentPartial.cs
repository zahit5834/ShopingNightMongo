using Microsoft.AspNetCore.Mvc;
using ShopingNightMongo.Services.CategoryServices;
using System.Threading.Tasks;

namespace ShopingNightMongo.ViewComponents
{
    public class _DefaultFilterComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DefaultFilterComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return View(categories);
        }
    }

}
