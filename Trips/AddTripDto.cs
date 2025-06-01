using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NauticaFreight.API.Ports;
using NauticaFreight.API.Vessels;

namespace NauticaFreight.API.Trips
{
    public class AddTripDto
    {
        [Required]
        public Guid VesselId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [Required]
        public int DeparturePortId { get; set; } // Primitive foreign key for DeparturePort
        
        [Required]
        [DataType(DataType.Date)]
        public DateTime EstArrivalDate { get; set; }        
        public int ArrivalPortId { get; set; }        
        public string? CargoType { get; set; }
        public int CargoWeight { get; set; }
        
    }
}
