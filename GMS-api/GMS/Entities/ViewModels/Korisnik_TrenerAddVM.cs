using GMS.Entities.Models;

namespace GMS.Entities.ViewModels
{
    public class Korisnik_TrenerAddVM
    {
        public int KorisnikID { get; set; }
        public int TrenerID { get; set; }
        public DateTime DatumTermina { get; set; }
        public int OdrzanoSati { get; set; }
    }
}
