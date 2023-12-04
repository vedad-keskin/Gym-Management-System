using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GMS.Entities.Models
{
    [Table("KorisnickiNalog")]
    public abstract class KorisnickiNalog
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public Korisnik? Korisnik => this as Korisnik;

        [JsonIgnore]
        public Administrator? Administrator => this as Administrator;
  
        public bool isAdministrator => Administrator != null;
        public bool isKorisnik => Korisnik != null;
     


    }
}
