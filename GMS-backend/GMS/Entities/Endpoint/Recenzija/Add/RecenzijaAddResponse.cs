namespace GMS.Entities.Endpoint.Recenzija.Add
{
    public class RecenzijaAddResponse
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Zanimanje { get; set; }
        public string Tekst { get; set; }
        public string? Slika { get; set; }
    }
}
