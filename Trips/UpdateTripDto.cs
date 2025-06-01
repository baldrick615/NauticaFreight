using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NauticaFreight.API.Ports;
using NauticaFreight.API.Vessels;

namespace NauticaFreight.API.Trips
{
    public class UpdateTripDto
    {
        [Required]
        public Guid VesselId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }

        [Required]
        public int DeparturePortId { get; set; } // Primitive foreign key for DeparturePort
        [ForeignKey(nameof(DeparturePortId))]
        public Port DeparturePort { get; set; } // Navigation property


        [Required]
        [DataType(DataType.Date)]
        public DateTime EstArrivalDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ActualArrivalDate { get; set; }

        public int ArrivalPortId { get; set; }
        [Required]
        [ForeignKey(nameof(ArrivalPortId))]
        public Port ArrivalPort { get; set; }

        public string? CargoType { get; set; }
        public int CargoWeight { get; set; }

        public DateTime LastUpdate { get; set; }
        public TripStatus Status { get; set; }

        //Navigation property for Vessel
        [ForeignKey(nameof(VesselId))]
        public Vessel Vessel { get; set; }
    }
}