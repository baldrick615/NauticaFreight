using Microsoft.EntityFrameworkCore;
using NauticaFreight.API.Data;

namespace NauticaFreight.API.Customers
{
    public class CustomerImpl : ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerImpl(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            await _db.Customers.AddAsync(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            return customer;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Customer?> UpdateAsync(int id, Customer customer)
        {
            var existingCustomer = await _db.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            
            if (existingCustomer == null)
            {
                return null;
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.Address = customer.Address;
            existingCustomer.City = customer.City;
            existingCustomer.State = customer.State;
            existingCustomer.Country = customer.Country;
            existingCustomer.PostCode = customer.PostCode;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Email = customer.Email;
            existingCustomer.CreditLimit = customer.CreditLimit;
            existingCustomer.PaymentTerms = customer.PaymentTerms;
            existingCustomer.CreateDate = customer.CreateDate;

            await _db.SaveChangesAsync();
            
            return existingCustomer;
        }
    }
}
