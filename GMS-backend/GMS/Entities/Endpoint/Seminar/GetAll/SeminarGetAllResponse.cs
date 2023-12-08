namespace GMS.Entities.Endpoint.Seminar.GetAll
{
    public class SeminarGetAllResponse
    {
        public List<SeminarGetAllResponseRow> Seminari { get; set; }
    }

    public class SeminarGetAllResponseRow // samo se radi kada je rezultat lista a ne jedan zapis 
    {
        public int ID { get; set; }
        public string Tema { get; set; }
        public string Predavac { get; set; }
        public DateTime Datum { get; set; }
        
    }
}
