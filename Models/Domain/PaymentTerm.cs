namespace NauticaFreight.API.Models.Domain
{
    public enum PaymentTerm
    {
        Net30,     // Payment due in 30 days
        Net60,     // Payment due in 60 days
        Net90,     // Payment due in 90 days
        DueOnReceipt, // Payment due immediately upon receipt
        Advance,   // Payment required before service or delivery
        Installments, // Payment split into multiple installments
        COD        // Cash on Delivery
    }

}