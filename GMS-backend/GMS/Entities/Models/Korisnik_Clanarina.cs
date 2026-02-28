using System.ComponentModel.DataAnnotations;

namespace GMS.Entities.Models
{
    public class Korisnik_Clanarina
    {
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
        public int ClanarinaID { get; set; }
        public Clanarina Clanarina { get; set; }

        public DateTime DatumUplate { get; set; }     
        public DateTime DatumIsteka { get; set; }     
    }
}
