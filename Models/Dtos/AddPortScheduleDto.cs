using NauticaFreight.API.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace NauticaFreight.API.Models.Dtos
{
    public class AddPortScheduleDto
    {
        
        [Required]
        public int PortId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime ArrivalDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DepartureDate { get; set; }
        [Range(0, int.MaxValue)]
        public int CapacityUtilized { get; set; }
        
    }
}
