namespace GMS.Entities.Endpoint.Trener.Edit
{
    public class TreneriEditRequest
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string? Slika { get; set; }
    }
}
