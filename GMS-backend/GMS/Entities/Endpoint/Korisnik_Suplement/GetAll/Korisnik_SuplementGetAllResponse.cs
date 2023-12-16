namespace GMS.Entities.Endpoint.KorisnikSuplement.GetAll
{
    public class Korisnik_SuplementGetAllResponse
    {
        public List<KorisnikSuplementGetAllResponseRow> KorisnikSuplement { get; set; }
    }

    public class KorisnikSuplementGetAllResponseRow
    {
        public int KorisnikID { get; set; }
        public string ImePrezime { get; set; }
        public int SuplementiID { get; set; }
        public string NazivSuplementa { get; set; }
        public DateTime DatumVrijemeNarudzbe { get; set; }
        public int Kolicina { get; set; }
        public float Cijena { get; set; }
        public float Ukupno { get; set; }
        public bool Isporuceno { get; set; }
    }
}
