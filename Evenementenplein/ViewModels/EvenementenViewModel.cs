using Evenementenplein.Models;

namespace Evenementenplein.ViewModels
{
    public class EvenementenViewModel
    {
        public int Id { get; set; }

        public string Naam { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }

        public Locatie Locatie { get; set; } = new Locatie();
    }
}
