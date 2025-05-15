using ShopingNightMongo.Dtos.CustormerDtos;

namespace ShopingNightMongo.Services.CustomerServices
{
    public interface ICustomerService
    {
        Task<List<ResultCustomerDto>> GetAllCustomersAsync();
        Task CreateCustomerAsync(CreateCustomerDto createCustomerDto);
        Task UpdateCustomerAsync (UpdateCustomerDto updateCustomerDto);
        Task DeleteCustomerAsync(string customerId);
        Task<GetCustomerByIdDto> GetCustomerByIdAsync(string customerId);
    }
}
