namespace GMS.Entities.Models
{
    public class Korisnik_Trener
    {
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        public int TrenerID { get; set; }
        public Trener Trener { get; set; }
        public DateTime DatumTermina { get; set; }
        public int OdrzanoSati { get; set; }
    }
}
