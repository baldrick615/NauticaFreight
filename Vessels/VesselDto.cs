using System.ComponentModel.DataAnnotations;

namespace NauticaFreight.API.Vessels
{
    public class VesselDto
    {
        public Guid VesselId { get; set; }

        [Required]
        public string VesselName { get; set; }
        [Required]
        public string Operator { get; set; }
        [Required]
        public string CountryOfOrigin { get; set; }
        public Category CargoCategory { get; set; }
        [Required]
        [Range(5000, 100000, ErrorMessage = "Must not exceed 100,000 tons")]
        public int CarryingCapacity { get; set; }
        
    }
}