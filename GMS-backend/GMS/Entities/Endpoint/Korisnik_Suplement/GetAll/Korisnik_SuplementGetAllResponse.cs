namespace GMS.Entities.Endpoint.KorisnikSuplement.GetAll
{
    public class Korisnik_SuplementGetAllResponse
    {
        public List<KorisnikSuplementGetAllResponseRow> KorisnikSuplement { get; set; }
    }

    public class KorisnikSuplementGetAllResponseRow
    {
        public int KorisnikID { get; set; }
        public int SuplementiID { get; set; }
        public DateTime DatumVrijemeNarudzbe { get; set; }
        public int Kolicina { get; set; }
    }
}
