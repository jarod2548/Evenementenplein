using Evenementenplein.Models;

namespace Evenementenplein.ViewModels
{
    public class EvenementenViewModel
    {
        public int Id { get; set; }

        public string Naam { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string BeginDatum { get; set; } = string.Empty;
        public string EindDatum { get; set; } = string.Empty;

        public string LocatieNaam { get; set; } = string.Empty;
        public string LocatieAdres { get; set; } = string.Empty;
    }
}
