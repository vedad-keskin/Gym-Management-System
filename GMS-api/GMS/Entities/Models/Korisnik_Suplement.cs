using System.ComponentModel.DataAnnotations;

namespace GMS.Entities.Models
{
    public class Korisnik_Suplement
    {
      
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        public int SuplementID { get; set; }
        public Suplement Suplement { get; set; }
        public DateTime DatumVrijemeNarudzbe { get; set; }
        public int Kolicina { get; set; }
    }
}
