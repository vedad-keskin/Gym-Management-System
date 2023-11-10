namespace GMS.Endpoint.Recenzija.GetAll
{
    public class RecenzijaGetAllResponse
    {
        public List<RecenzijeGetAllResponseRow> Recenzije { get; set; }
    }

    public class RecenzijeGetAllResponseRow // samo se radi kada je rezultat lista a ne jedan zapis 
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Zanimanje { get; set; }
        public string Tekst { get; set; }
        public string? Slika { get; set; }
    }
}
