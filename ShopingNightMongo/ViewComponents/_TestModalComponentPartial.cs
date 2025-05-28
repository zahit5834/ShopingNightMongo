using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ShopingNightMongo.Entities;
using ShopingNightMongo.Models;
using ShopingNightMongo.Services.ProductServices;
using ShopingNightMongo.Settings;

namespace ShopingNightMongo.ViewComponents
{
    public class _TestModalComponentPartial : ViewComponent
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<ProductImage> _productImageCollection;

        public _TestModalComponentPartial(IProductService products, IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            _mapper = mapper;
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            var imagedatabase = client.GetDatabase(_databaseSettings.ProductImageCollectionName);
            _productImageCollection = imagedatabase.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }
            else
            {
                var product = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
                var images = await _productImageCollection.Find(x => x.ProductId == id).ToListAsync();

                var vm = new ProductWithImages { Product = product, ProductImage = images };
                Console.WriteLine(vm.Product.ProductName);
                return View(vm);
            }
        }
    }
}