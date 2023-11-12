namespace GMS.Entities.Endpoint.Korisnik_Nutricionist.GetAll
{
    public class Korisnik_NutricionistGetAllResponse
    {
        public List<KorisnikNutricionistGetAllResponseRow> KorisnikNutricionist { get; set; }
    }

    public class KorisnikNutricionistGetAllResponseRow
    {
        public int KorisnikID { get; set; }
        public int NutricionistID { get; set; }
        public DateTime DatumTermina { get; set; }
        public DateTime OdrzanoSati { get; set; }

    }
}
