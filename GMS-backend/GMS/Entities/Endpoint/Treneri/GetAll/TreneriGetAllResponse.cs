namespace GMS.Entities.Endpoint.Treneri.GetAll
{
    public class TreneriGetAllResponse
    {
        public List<TreneriGetAllResponseRow> Treneri { get; set; }
    }

    public class TreneriGetAllResponseRow
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
    }
}
