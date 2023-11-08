using GMS.Entities.Models;

namespace GMS.Entities.ViewModels
{
    public class Korisnik_SuplementAddVM
    {
        public int KorisnikID { get; set; }
        public int SuplementID { get; set; }
        public DateTime DatumVrijemeNarudzbe { get; set; }
        public int Kolicina { get; set; }
    }
}
