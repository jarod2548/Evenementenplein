namespace Evenementenplein.Models
{
    public class TicketType
    {
        public int ID { get; set; }
        public string Naam { get; set; } = string.Empty;
        public int AantalTotaal { get; set; }
        public int AantalBeschikbaar { get; set; }
        public decimal Prijs {  get; set; }

    }
}
