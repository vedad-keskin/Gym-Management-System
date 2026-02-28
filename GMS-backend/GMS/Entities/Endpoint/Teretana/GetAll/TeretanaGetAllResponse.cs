namespace GMS.Entities.Endpoint.Teretana.GetAll
{
    public class TeretanaGetAllResponse
    {
        public List<TeretanaGetAllResponseRow> Teretane { get; set; }
    }

    public class TeretanaGetAllResponseRow // samo se radi kada je rezultat lista a ne jedan zapis 
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public int GradID { get; set; }
        public string NazivGrada { get; set; }
        public string Adresa { get; set; }
    }
}
