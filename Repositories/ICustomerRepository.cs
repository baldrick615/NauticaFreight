using NauticaFreight.API.Models.Domain;

namespace NauticaFreight.API.Repositories;

public interface ICustomerRepository
{
    Task<List<Customer>> GetAllCustomers();
    Task<Customer?> GetCustomerById(int id);
    Task<Customer> CreateCustomer(Customer customer);
    Task<Customer> UpdateCustomer(int id, Customer customer);
    Task<Customer> DeleteCustomer(int id);
    
}