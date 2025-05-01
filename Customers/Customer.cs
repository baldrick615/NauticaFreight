using System.ComponentModel.DataAnnotations;
using NauticaFreight.API.Models.Domain;

namespace NauticaFreight.API.Customers;

public class Customer
{
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public string Name { get; set; }
    public string Address { get; set; }
    [Required]
    public string City { get; set; }
    
    public string State { get; set; }
    public string Country { get; set; }
    public string PostCode { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string Phone { get; set; }
    
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
    
    [DataType(DataType.Currency)]
    [Range(0, 5000000, ErrorMessage = "Credit limit must be greater than zero")]
    public decimal CreditLimit { get; set; }
    // use PaymentTerm enum
    //[Required]
    [EnumDataType(typeof(PaymentTerm))]
    public PaymentTerm PaymentTerms { get; set; }

    public DateTime CreateDate { get; set; } = DateTime.Now;
    public DateTime LastUpdate { get; set; } = DateTime.Now;
}