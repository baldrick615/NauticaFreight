using System.ComponentModel.DataAnnotations;

namespace NauticaFreight.API.Ports
{
    public class AddPortDto
    {
        [Required(ErrorMessage = "Port name is required")]
        public string PortName { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string LocationCity { get; set; }
        public string LocationCountry { get; set; }
        [Required(ErrorMessage = "Capacity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
        public int Capacity { get; set; }
        public decimal Demurrage { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
