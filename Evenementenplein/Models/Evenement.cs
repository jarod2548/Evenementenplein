namespace Evenementenplein.Models
{
    public class Evenement
    {
        public int Id { get; private set; }
        public string Naam { get; private set; } = string.Empty;
        public string Beschrijving { get; private set; } = string.Empty;
        public int Capaciteit { get; private set; }
        public DateTime BeginDatum { get; private set; }
        public DateTime EindDatum { get; private set; }
    }
}
