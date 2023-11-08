using System.ComponentModel.DataAnnotations;

namespace GMS.Entities.Models
{
    public class Recenzija
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Zanimanje { get; set; }
        public string Tekst { get; set; }
        // public IFormFile Slika { get; set; }

    }
}
