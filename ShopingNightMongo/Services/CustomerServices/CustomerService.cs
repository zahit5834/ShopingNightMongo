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
        public CustomerService(IMapper mapper, IDatabaseSettings _databaseSettings)
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
            await _customerCollection.DeleteOneAsync(x => x.CustomerId == customerId);
        }

        public async Task<List<ResultCustomerDto>> GetAllCustomersAsync()
        {
            var values = await _customerCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCustomerDto>>(values);
        }

        public async Task<GetCustomerByIdDto> GetCustomerByIdAsync(string customerId)
        {
            var value = await _customerCollection.Find(x => x.CustomerId == customerId).FirstOrDefaultAsync();
            return _mapper.Map<GetCustomerByIdDto>(value);
        }

        public async Task UpdateCustomerAsync(UpdateCustomerDto updateCustomerDto)
        {
            var value = _mapper.Map<Customer>(updateCustomerDto);
            await _customerCollection.FindOneAndReplaceAsync(x => x.CustomerId == updateCustomerDto.CustomerId, value);
        }
    }
}
