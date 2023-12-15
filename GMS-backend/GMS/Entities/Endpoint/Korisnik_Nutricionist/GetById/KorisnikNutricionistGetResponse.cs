namespace GMS.Entities.Endpoint.Korisnik_Nutricionist.GetById
{
    public class KorisnikNutricionistGetResponse
    {
        public int KorisnikID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public List<KorisnikNutricionistGetResponseZakazaniTermini> ZakazaniTermini { get; set; }
    }

    public class KorisnikNutricionistGetResponseZakazaniTermini
    {
        public int KorisnikID { get; set; }
        public int NutricionistID { get; set; }
        public DateTime DatumTermina { get; set; }
        public DateTime OdrzanoSati { get; set; }

    }
}
