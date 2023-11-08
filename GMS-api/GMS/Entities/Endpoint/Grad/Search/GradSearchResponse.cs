namespace GMS.Endpoint.Drzava.Search
{
    public class GradSearchResponse
    {
        public List<GradSearchResponseDodatak> Gradovi { get; set; }
    }

    public class GradSearchResponseDodatak // samo se radi kada je rezultat lista a ne jedan zapis 
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
    }

}
