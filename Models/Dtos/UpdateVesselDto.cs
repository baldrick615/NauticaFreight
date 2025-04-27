using NauticaFreight.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace NauticaFreight.API.Models.Dtos
{
    public class UpdateVesselDto
    {
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
