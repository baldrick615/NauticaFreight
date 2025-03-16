using NauticaFreight.API.Models.Domain;

namespace NauticaFreight.API.Repositories
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> CreateAsync(Customer customer);
        Task<Customer?> UpdateAsync(int id, Customer customer);
        Task<Customer> DeleteCustomer(int id);

    }
}
