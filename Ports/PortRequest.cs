using System.ComponentModel.DataAnnotations;

namespace NauticaFreight.API.Ports;

    public class PortRequest
    {
        [Required]
        public int PortId { get; set; }
        [Required]
        public string PortName { get; set; }
        [Required]
        public string LocationCity { get; set; }
        [Required]
        public string LocationCountry { get; set; }
        [Required]
        public int Capacity { get; set; }
        public decimal Demurrage { get; set; }
        
    }

