using AutoMapper;
using MongoDB.Driver;
using ShopingNightMongo.Dtos.ProductImageDtos;
using ShopingNightMongo.Entities;
using ShopingNightMongo.Settings;

namespace ShopingNightMongo.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMongoCollection<Product> _productCollection;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.ProductImageCollectionName);
            _productImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
            var productDatabase = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = productDatabase.GetCollection<Product>(_databaseSettings.ProductCollectionName);

        }


        public async Task CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto);
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImage(string id)
        {
            await _productImageCollection.DeleteOneAsync(x => x.ProductImageId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var productImages = await _productImageCollection
     .Find(x => true)
     .ToListAsync();

            if (productImages.Any())
            {
                var productIds = productImages.Select(x => x.ProductId).ToList();
                var products = await _productCollection
                    .Find(x => productIds.Contains(x.ProductId))
                    .ToListAsync();

                // Her bir productImage için ilgili product'ı eşleştir
                foreach (var productImage in productImages)
                {
                    var s = products.FirstOrDefault(p => p.ProductId == productImage.ProductId);
                    productImage.ProductName = s.ProductName;
                }
            }

            return _mapper.Map<List<ResultProductImageDto>>(productImages);

        }

        public async Task<GetProductImageDto> GetProductImageByIdAsync(string id)
        {
            var productImage = await _productImageCollection.Find(x => x.ProductImageId == id).FirstOrDefaultAsync();

            if (productImage != null)
            {
                var product = await _productCollection
                    .Find(x => x.ProductId == productImage.ProductId)
                    .FirstOrDefaultAsync();

                // İki nesneyi birleştir
                productImage.ProductName = product.ProductName;
                Console.WriteLine(productImage.ProductName);
            }
            return _mapper.Map<GetProductImageDto>(productImage);
        }

        public async Task UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, value);
        }

        
    }
}
