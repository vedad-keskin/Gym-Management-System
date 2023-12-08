
namespace GMS.Entities.Endpoint.Kategorija.GetAll
{
    public class KategorijaGetAllResponse
    {
        public List<KategorijaGetAllResponseRow> Kategorije { get; set; }
    }
    public class KategorijaGetAllResponseRow // samo se radi kada je rezultat lista a ne jedan zapis 
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
    }
}
