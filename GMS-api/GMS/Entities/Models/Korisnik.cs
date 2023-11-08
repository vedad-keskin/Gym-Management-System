using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Entities.Models
{
    public class Korisnik
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        // public IFormFile? Slika { get; set; }

        public string BrojTelefona { get; set; }
        public float Visina { get; set; }
        public float Tezina { get; set; }

        [ForeignKey(nameof(Grad))]
        public int GradID { get; set; }
        public Grad Grad { get; set; }

        [ForeignKey(nameof(Spol))]
        public int SpolID { get; set; }
        public Spol Spol { get; set; }

        [ForeignKey(nameof(Teretana))]
        public int TeretanaID { get; set; }
        public Teretana Teretana { get; set; }

        // public ICollection<Korisnik_Clanarina> Clanarine { get; set; }


    }
}
