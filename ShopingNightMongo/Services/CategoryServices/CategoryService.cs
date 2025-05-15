﻿using AutoMapper;
using MongoDB.Driver;
using ShopingNightMongo.Dtos.CategoryDtos;
using ShopingNightMongo.Dtos.CustormerDtos;
using ShopingNightMongo.Entities;
using ShopingNightMongo.Settings;

namespace ShopingNightMongo.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Category> _categoryCollection;
        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(id);
        }

        public Task<List<ResultCategoryDto>> GetAllCategories()
        {
            throw new NotImplementedException();
        }

        public Task<GetCategoryDto> GetCategoryByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var value = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, value);
        }
    }
}