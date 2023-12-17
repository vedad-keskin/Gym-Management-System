namespace GMS.Entities.Endpoint.Korisnik_Trener.GetById
{
    public class KorisnikTrenerGetResponse
    {
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public List<KorisnikTrenerGetResponseZakazaniTermini> ZakazaniTermini { get; set; }
    }

    public class KorisnikTrenerGetResponseZakazaniTermini
    {
        public int KorisnikID { get; set; }
        public int TrenerID { get; set; }
        public int ZakazanoSati { get; set; }
        public DateTime DatumTermina { get; set; }
    }
}
