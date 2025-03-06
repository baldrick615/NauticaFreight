namespace NauticaFreight.API.Models.Domain;

public class Port
{
    public int PortId { get; set; }
    public string PortName { get; set; }
    public string LocationCity { get; set; }
    public string LocationCountry { get; set; }
    public int Capacity { get; set; }
    public decimal Demurrage { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdate { get; set; }
}