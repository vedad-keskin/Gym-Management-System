namespace GMS.Entities.Endpoint.Dobavljac.GetAll
{
    public class DobavljacGetAllResponse
    {
        public List<DobavljacGetAllResponseRow> Dobavljaci { get; set; }
    }

    public class DobavljacGetAllResponseRow // samo se radi kada je rezultat lista a ne jedan zapis 
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
