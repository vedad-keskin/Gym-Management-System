namespace GMS.Entities.Endpoint.Korisnik_Trener.Add
{
    public class Korisnik_TrenerAddResponse
    {
        public int KorisnikID { get; set; }
        public int TrenerID { get; set; }

        public DateTime DatumTermina { get; set; }
        public int ZakazanoSati { get; set; }
    }
}
