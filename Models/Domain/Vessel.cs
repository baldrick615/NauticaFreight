using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NauticaFreight.API.Models.Domain
{
    public class Vessel
    {
        [Key]
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


    public enum Category
    {
        [Description("Container")]
        Container,
        [Description("Bulk")]
        Bulk,
        [Description("Tanker")]
        Tanker,
        [Description("General")]
        General,
        [Description("Barge")]
        Barge
    }
}
