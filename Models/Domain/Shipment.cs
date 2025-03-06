using System.ComponentModel.DataAnnotations;

namespace NauticaFreight.API.Models.Domain;

public class Shipment
{
    public Guid ShipmentId { get; set; }
    public int InvoiceId { get; set; }
    public DateOnly ShipmentDate { get; set; }
    public int OriginPort { get; set; }
    public int DestinationPort { get; set; }
    public DateTime EstimatedArrivalDate { get; set; }
    public DateTime ArrivalDate { get; set; }
    public decimal Weight { get; set; }
    public string Status { get; set; }
}