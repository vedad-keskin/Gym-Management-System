namespace GMS.Entities.Endpoint.Korisnik_Suplement.Add
{
    public class Korisnik_SuplementAddRequest
    {
        public int KorisnikID { get; set; }
        public int SuplementID { get; set; }
        public DateTime DatumVrijemeNarudzbe { get; set; }
        public int Kolicina { get; set; }
        public bool Isporuceno { get; set; }

    }
}
