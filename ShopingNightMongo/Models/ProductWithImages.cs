using ShopingNightMongo.Entities;

namespace ShopingNightMongo.Models
{
    public class ProductWithImages
    {
        public Product Product { get; set; }
        public List<ProductImage> ProductImage { get; set; } 
    }
}
