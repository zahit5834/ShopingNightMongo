using Microsoft.AspNetCore.Mvc;
using ShopingNightMongo.Services.ProductServices;
using System.Threading.Tasks;

namespace ShopingNightMongo.ViewComponents
{
    public class _DefaultProductsComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductsComponentPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
    }
}