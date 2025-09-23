using Evenementenplein.Models.Enums;

namespace Evenementenplein.Models
{
    public class Evenement
    {
        public int Id { get; set; }
        public string Naam { get; set; } = string.Empty;
        public string Beschrijving { get; set; } = string.Empty;
        public EvenementType Type { get; set; }
        public int Capaciteit { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }

        public Locatie Locatie { get;  set; } = new Locatie();
    }
}
