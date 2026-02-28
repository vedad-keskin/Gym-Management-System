namespace GMS.Entities.Endpoint.Spol.GetAll
{
    public class SpolGetAllResponse
    {
        public List<SpolGetAllResponseRow> Spolovi { get; set; }
    }

    public class SpolGetAllResponseRow // samo se radi kada je rezultat lista a ne jedan zapis 
    {
        public int ID { get; set; }
        public string Naziv { get; set; }

    }
}
