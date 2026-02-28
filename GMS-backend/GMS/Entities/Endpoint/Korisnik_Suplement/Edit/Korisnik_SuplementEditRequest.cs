namespace GMS.Entities.Endpoint.Korisnik_Suplement.Edit
{
    public class Korisnik_SuplementEditRequest
    {
        public int KorisnikID { get; set; }
       
        public int SuplementID { get; set; }
       
        public DateTime DatumVrijemeNarudzbe { get; set; }
        public int Kolicina { get; set; }
        public bool Isporuceno { get; set; }
    }
}
