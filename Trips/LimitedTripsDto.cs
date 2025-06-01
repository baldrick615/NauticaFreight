using System.ComponentModel.DataAnnotations;

namespace NauticaFreight.API.Trips
{
    public class LimitedTripsDto
    {
        public Guid Id { get; set; }
        public Guid VesselId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }        
        public int DeparturePortId { get; set; }        
        [DataType(DataType.Date)]
        public DateTime EstArrivalDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime ActualArrivalDate { get; set; }

        public int ArrivalPortId { get; set; }

        public string? CargoType { get; set; }
        public int CargoWeight { get; set; }

        public TripStatus Status { get; set; }
    }
}
