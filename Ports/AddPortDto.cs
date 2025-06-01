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
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        public decimal Latitude { get; set; }
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
        public decimal Longitude { get; set; }

        [Required(ErrorMessage = "Capacity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Capacity must be greater than 0")]
        public int Capacity { get; set; }
        public decimal Demurrage { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
