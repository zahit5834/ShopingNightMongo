﻿using AutoMapper;
using MongoDB.Driver;
using ShopingNightMongo.Dtos.CustormerDtos;
using ShopingNightMongo.Entities;
using ShopingNightMongo.Settings;

namespace ShopingNightMongo.Services.CustomerServices
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Customer> _customerCollection;
        public CustomerService(IMapper mapper,IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _customerCollection = database.GetCollection<Customer>(_databaseSettings.CustomerCollectionName);
            _mapper = mapper;
        }

        
        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            var value = _mapper.Map<Customer>(createCustomerDto);
            await _customerCollection.InsertOneAsync(value);
        }

        public async Task DeleteCustomerAsync(string customerId)
        {
            await _customerCollection.DeleteOneAsync(customerId);
        }

        public Task<List<ResultCustomerDto>> GetAllCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetCustomerByIdDto> GetCustomerByIdAsync(string customerId)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            var value = _mapper.Map<Customer>(updateCustomerDto);
            await _customerCollection.FindOneAndReplaceAsync(x => x.CustomerId == updateCustomerDto.CustomerId, value);
        }
    }
}
