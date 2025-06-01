using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace NauticaFreight.API.Ports
{
    public class UpdatePortDto
    {
        public string PortName { get; set; }
        public string LocationCity { get; set; }
        public string LocationCountry { get; set; }
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90")]
        public decimal Latitude { get; set; }
        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180")]
        public decimal Longitude { get; set; }
        public int Capacity { get; set; }
        public decimal Demurrage { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
