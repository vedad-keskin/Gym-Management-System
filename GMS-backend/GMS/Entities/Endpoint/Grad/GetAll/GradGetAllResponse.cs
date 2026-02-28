
namespace GMS.Entities.Endpoint.Grad.GetAll
{
    public class GradGetAllResponse
    {
        public List<GradGetAllResponseRow> Gradovi { get; set; }
    }

    public class GradGetAllResponseRow // samo se radi kada je rezultat lista a ne jedan zapis 
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
