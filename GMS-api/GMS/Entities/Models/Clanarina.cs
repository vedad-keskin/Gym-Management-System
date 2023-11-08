using System.ComponentModel.DataAnnotations;

namespace GMS.Entities.Models
{
    public class Clanarina
    {
        [Key]
        public int ID { get; set; }
        public string Naziv { get; set; }
        public float Cijena { get; set; }

        // public ICollection<Korisnik_Clanarina> Korisnici { get; set; }
    }
}
