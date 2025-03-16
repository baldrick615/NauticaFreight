using Microsoft.EntityFrameworkCore;
using NauticaFreight.API.Data;
using NauticaFreight.API.Models.Domain;

namespace NauticaFreight.API.Repositories;

public class CustomerImpl : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerImpl(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Customer>> GetAllCustomers()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer?> GetCustomerById(int id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        return customer;
    }

    public Task<Customer> CreateCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> UpdateCustomer(int id, Customer customer)
    {
        throw new NotImplementedException();
    }

    public Task<Customer> DeleteCustomer(int id)
    {
        throw new NotImplementedException();
    }
}