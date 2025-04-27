using NauticaFreight.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace NauticaFreight.API.Models.Dtos
{
    public class PortScheduleDto
    {
        [Required]
        [Key]
        public int ScheduleId { get; set; }
        [Required]
        public int PortId { get; set; }
        public Guid VesselId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
        [Range(0, int.MaxValue)]
        public int CapacityUtilized { get; set; }

        public PortDto Port { get; set; }
        public VesselDto Vessel{ get; set; }
    }
}
