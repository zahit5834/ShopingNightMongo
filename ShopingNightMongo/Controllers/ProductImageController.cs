using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopingNightMongo.Dtos.ProductImageDtos;
using ShopingNightMongo.Entities;
using ShopingNightMongo.Services.ProductImageServices;
using ShopingNightMongo.Services.ProductServices;
using System.Threading.Tasks;

namespace ShopingNightMongo.Controllers
{
    public class ProductImageController : Controller
    {
        private readonly IProductImageService _productImageService;
        private readonly IProductService _productService;
        public ProductImageController(IProductImageService productImageService, IProductService productService)
        {
            _productImageService = productImageService;
            _productService = productService;
        }

        public async Task<IActionResult> ProductImageList()
        {
            var values = await _productImageService.GetAllProductImagesAsync();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> CreateProductImage()
        {
            var products = await _productService.GetAllProductAsync();
            ViewBag.v = products.Select(p => new SelectListItem
            {
                Text = p.ProductName,
                Value = p.ProductId.ToString()
            }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            _productImageService.CreateProductImage(createProductImageDto);
            return RedirectToAction("ProductImageList");
        }
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImage(id);
            return RedirectToAction("ProductImageList");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
            var products = await _productService.GetAllProductAsync();
            ViewBag.v = products.Select(p => new SelectListItem
            {
                Text = p.ProductName,
                Value = p.ProductId.ToString()
            }).ToList();
            var value = await _productImageService.GetProductImageByIdAsync(id);
            return View(value);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImage(updateProductImageDto);
            return RedirectToAction("ProductImageList");
        }
    }
}
