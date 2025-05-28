using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ShopingNightMongo.Entities;
using ShopingNightMongo.Models;
using ShopingNightMongo.Services.ProductImageServices;
using ShopingNightMongo.Services.ProductServices;
using System.Threading.Tasks;

namespace ShopingNightMongo.ViewComponents
{
    public class _DefaultModalComponentPartial : ViewComponent
    {
        private readonly IProductService _products;

        public _DefaultModalComponentPartial(IProductService products)
        {
            _products = products;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}