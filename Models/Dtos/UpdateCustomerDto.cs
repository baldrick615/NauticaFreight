using System.ComponentModel.DataAnnotations;

namespace NauticaFreight.API.Models.Dtos
{
    public class UpdateCustomerDto
    {
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

        [Range(0, 5000000, ErrorMessage = "Credit limit must be greater than zero")]
        public decimal CreditLimit { get; set; }
        public string PaymentTerms { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
