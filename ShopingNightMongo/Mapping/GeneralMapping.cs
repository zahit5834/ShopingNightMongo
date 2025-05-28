using AutoMapper;
using ShopingNightMongo.Dtos.CategoryDtos;
using ShopingNightMongo.Dtos.CustormerDtos;
using ShopingNightMongo.Dtos.GaleryDtos;
using ShopingNightMongo.Dtos.ProductDtos;
using ShopingNightMongo.Dtos.ProductImageDtos;
using ShopingNightMongo.Entities;

namespace ShopingNightMongo.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, ResultCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();

            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, ResultCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<Customer, GetCustomerByIdDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetProductByIdDto>().ReverseMap();

            CreateMap<Galery, CreateGaleryDto>().ReverseMap();
            CreateMap<Galery, ResultGaleryDto>().ReverseMap();
            CreateMap<Galery, UpdateGaleryDto>().ReverseMap();
            CreateMap<Galery, GetGaleryDto>().ReverseMap();

            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetProductImageDto>().ReverseMap();


        }
    }
}
