namespace NauticaFreight.API.Models.Domain;

public class Invoice
{
    public int InvoiceId { get; set; }
    public int CustomerId { get; set; }
    public DateTime InvoiceDate { get; set; }
    public DateTime ShippingDate { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal AmountPaid { get; set; }
    public bool IsOpen { get; set; } = true;
    public DateTime LastUpdate { get; set; }
}