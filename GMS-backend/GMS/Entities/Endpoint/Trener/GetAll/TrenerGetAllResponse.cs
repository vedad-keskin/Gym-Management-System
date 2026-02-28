namespace GMS.Entities.Endpoint.Trener.GetAll
{
    public class TrenerGetAllResponse
    {
        public List<TreneriGetAllResponseRow> Treneri { get; set; }
    }

    public class TreneriGetAllResponseRow
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string? Slika { get; set; }
    }
}
