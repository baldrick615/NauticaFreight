using System.ComponentModel.DataAnnotations;

namespace NauticaFreight.API.Ports;

public class PortSchedule
{
    [Required]
    [Key]
    public int ScheduleId { get; set; }
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

    public Port Port { get; set; }
}