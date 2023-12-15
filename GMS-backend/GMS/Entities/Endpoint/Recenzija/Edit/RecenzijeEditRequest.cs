namespace GMS.Entities.Endpoint.Recenzija.Edit
{
    public class RecenzijeEditRequest
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Zanimanje { get; set; }
        public string Tekst { get; set; }
        public string? Slika { get; set; }
    }
}
