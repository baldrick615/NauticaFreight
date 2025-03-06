namespace NauticaFreight.API.Models.Domain;

public class PortSchedule
{
    public int ScheduleId { get; set; }
    public int PortId { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
    public int CapacityUtilized { get; set; }
}