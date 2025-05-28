using Microsoft.AspNetCore.Mvc;
using ShopingNightMongo.Services.ProductServices;

namespace ShopingNightMongo.ViewComponents
{
    public class _TestProductsComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _TestProductsComponentPartial(IProductService productService)
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