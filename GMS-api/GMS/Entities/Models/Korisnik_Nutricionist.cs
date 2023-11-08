namespace GMS.Entities.Models
{
    public class Korisnik_Nutricionist
    {
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        public int NutricionistID { get; set; }
        public Nutricionist Nutricionist { get; set; }
        public DateTime DatumTermina { get; set; }
    }
}
