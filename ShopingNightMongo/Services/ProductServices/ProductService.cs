using AutoMapper;
using MongoDB.Driver;
using ShopingNightMongo.Dtos.ProductDtos;
using ShopingNightMongo.Entities;
using ShopingNightMongo.Settings;

namespace ShopingNightMongo.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Category> _categoryCollection;
        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _mapper = mapper;
            var categoryDatabase = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = categoryDatabase.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var products = await _productCollection.Find(x => true).ToListAsync();
            if (products.Any())
            {
                var CategoryIds = products.Select(x => x.CategoryId).ToList();
                var categories = await _categoryCollection.Find(x => CategoryIds.Contains(x.CategoryId)).ToListAsync();
                foreach (var product in products)
                {
                    var s= categories.FirstOrDefault(c => c.CategoryId == product.CategoryId);
                    product.CategoryName= s.CategoryName;
                }
            }
            return _mapper.Map<List<ResultProductDto>>(products);

        }

        public async Task<GetProductByIdDto> GetProductByIdAsync(string id)
        {
            var value = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetProductByIdDto>(value);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, value);
        }
    }
}
