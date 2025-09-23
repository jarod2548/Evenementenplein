namespace EvenementenPleinMapper
{
    public class EvenementDTO
    {
        public int Id { get;  set; }
        public string Naam { get;  set; } = string.Empty;
        public string Beschrijving { get; set; } = string.Empty;
        public int Capaciteit { get; set; }
        public int EvenementType { get; set; }
        public DateTime BeginDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public int LocatieID { get; set; }

    }
}
