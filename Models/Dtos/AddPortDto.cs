namespace NauticaFreight.API.Models.Dtos
{
    public class AddPortDto
    {
        public string PortName { get; set; }
        public string LocationCity { get; set; }
        public string LocationCountry { get; set; }
        public int Capacity { get; set; }
        public decimal Demurrage { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
