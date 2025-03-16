using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NauticaFreight.API.Data;
using NauticaFreight.API.Models.Domain;
using NauticaFreight.API.Models.Dtos;
using NauticaFreight.API.Repositories;

namespace NauticaFreight.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;

    public CustomerController(ICustomerRepository customerRepository, IMapper mapper, ApplicationDbContext context)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _context = context;
    }

    [HttpGet]
    [Route("GetCustomers")]
    public async Task <ActionResult<Customer>> GetCustomers()
    {
        var customers = await _customerRepository.GetAllCustomers();
        var customersDto = _mapper.Map<List<CustomerDto>>(customers);
        return Ok(customersDto);
    }

    [HttpGet]
    [Route("GetCustomerById/{id:int}")]
    public async Task<ActionResult<Customer>> GetCustomerById(int id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        if (customer == null)
        {
            return NotFound("Customer not found!");
        }
        return Ok(_mapper.Map<CustomerDto>(customer));
    }
    
    [HttpPost]
    [Route("AddCustomer")]
    public async Task<ActionResult<Customer>> AddCustomer(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetCustomerById", new { id = customer.CustomerId }, customer);
    }
    
    [HttpPut]
    [Route("UpdateCustomer/{id:int}")]
    public async Task<ActionResult<Customer>> UpdateCustomer(int id, [FromBody] Customer customer)
    {
        var customertoUpdate = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        if (customertoUpdate == null)
        {
            return NotFound();
        }
        
        customertoUpdate.Name = customer.Name;
        customertoUpdate.Address = customer.Address;
        customertoUpdate.City = customer.City;
        customertoUpdate.State = customer.State;
        customertoUpdate.Country = customer.Country;
        customertoUpdate.PostCode = customer.PostCode;
        customertoUpdate.Phone = customer.Phone;
        customertoUpdate.Email = customer.Email;
        customertoUpdate.CreditLimit = customer.CreditLimit;
        customertoUpdate.PaymentTerms = customer.PaymentTerms;
        customertoUpdate.LastUpdate = DateTime.Now;
        
        return Ok(customertoUpdate);
    }
    
    [HttpDelete]
    [Route("DeleteCustomer/{id:int}")]
    public async Task<ActionResult<Customer>> DeleteCustomer(int id)
    {
        var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        if (customer == null)
        {
            return NotFound();
        }
        
        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return Ok();
    }
}