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
    private readonly ICustomerRepository _customerImpl;
    private readonly IMapper _mapper;

    public CustomerController(ICustomerRepository customerImpl, IMapper mapper)
    {
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
    public async Task<ActionResult<Customer>> AddCustomer(AddCustomerDto addCustomerDto)
    {
        var customerDomainModel = _mapper.Map<Customer>(addCustomerDto);
        customerDomainModel = await _customerImpl.CreateAsync(customerDomainModel);
        var customerDto = _mapper.Map<CustomerDto>(customerDomainModel);

        return CreatedAtAction(nameof(GetCustomerById), new { id = customerDto.CustomerId }, customerDto);
    }
    
    [HttpPut]
    [Route("UpdateCustomer/{id:int}")]
    public async Task<ActionResult<Customer>> UpdateCustomer([FromRoute] int id, [FromBody] UpdateCustomerDto updateCustomerDto)
    {
        var customerToUpdate = _mapper.Map<Customer>(updateCustomerDto);
        
        if (customerToUpdate == null)
            return NotFound("Customer not found!");

        customerToUpdate = await _customerImpl.UpdateAsync(id, customerToUpdate);

        return Ok(_mapper.Map<CustomerDto>(customerToUpdate));
    }
    
    [HttpDelete]
    [Route("DeleteCustomer/{id:int}")]
    public async Task<ActionResult<Customer>> DeleteCustomer([FromRoute] int id)
    {
        var customer = await _customerImpl.DeleteCustomer(id);

        if (customer == null)
            return NotFound("Customer not found!");

        return Ok(_mapper.Map<CustomerDto>(customer));
    }
}