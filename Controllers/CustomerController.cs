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
    private readonly ApplicationDbContext _context;
    private readonly ICustomerRepository _customerImpl;
    private readonly IMapper _mapper;

    public CustomerController(ApplicationDbContext context, ICustomerRepository customerImpl, IMapper mapper)
    {
        _context = context;
        _customerImpl = customerImpl;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("GetCustomers")]
    public async Task <ActionResult<Customer>> GetCustomers()
    {
        var customers = await _customerImpl.GetCustomers();
        return Ok(_mapper.Map<List<CustomerDto>>(customers));
    }

    [HttpGet]
    [Route("GetCustomerById/{id:int}")]
    public async Task<ActionResult<Customer>> GetCustomerById(int id)
    {
        var customer = await _customerImpl.GetCustomerById(id);
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
        var customerToAdd = await _customerImpl.CreateAsync(customer);
        
        return CreatedAtAction("GetCustomerById", new { id = customer.CustomerId }, customerToAdd);
    }
    
    [HttpPut]
    [Route("UpdateCustomer/{id:int}")]
    public async Task<ActionResult<Customer>> UpdateCustomer(int id, [FromBody] UpdateCustomerDto updateCustomerDto)
    {
        var customertoUpdate = _mapper.Map<Customer>(updateCustomerDto);
        
        if (customertoUpdate == null)
            return NotFound("Customer not found!");

        var updatedCustomer = await _customerImpl.UpdateAsync(id, customertoUpdate);


        return Ok(_mapper.Map<CustomerDto>(updatedCustomer));
    }
    
    [HttpDelete]
    [Route("DeleteCustomer/{id:int}")]
    public async Task<ActionResult<Customer>> DeleteCustomer(int id)
    {
        var customer = await _customerImpl.DeleteCustomer(id);
        
        return Ok();
    }
}