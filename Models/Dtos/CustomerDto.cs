using System.ComponentModel.DataAnnotations;
using NauticaFreight.API.Models.Domain;

namespace NauticaFreight.API.Models.Dtos
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        [Required(ErrorMessage = "Use INTL for international customers")]
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
        public PaymentTerm PaymentTerms { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; } = DateTime.Now;
    }
}