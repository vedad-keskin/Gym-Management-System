namespace GMS.Entities.Endpoint.Suplement.GetAll
{
    public class SuplementGetAllResponse
    {
        public List<SuplementGetAllResponseRow> Suplementi { get; set; }
    }


    public class SuplementGetAllResponseRow // samo se radi kada je rezultat lista a ne jedan zapis 
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }
        public float Gramaza { get; set; }
        public string Opis { get; set; }
        public string? Slika { get; set; }
        public string NazivDobavljaca { get; set; }
        public string NazivKategorija { get; set; }
    }
}
