namespace GMS.Entities.Endpoint.Korisnik_Trener.Add
{
    public class Korisnik_TrenerAddRequest
    {
        public int KorisnikID { get; set; }
        public int TrenerID { get; set; }

        public DateTime DatumTermina { get; set; }
        public int OdrzanoSati { get; set; }
    }
}
