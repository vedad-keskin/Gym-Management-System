namespace GMS.Entities.Endpoint.Korisnik_Nutricionist.Add
{
    public class Korisnik_NutricionistAddRequest
    {
        public int KorisnikID { get; set; }
        public int NutricionistID { get; set; }
       
        public DateTime DatumTermina { get; set; }
        public DateTime OdrzanoSati { get; set; }
    }
}
