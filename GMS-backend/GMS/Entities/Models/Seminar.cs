using System.ComponentModel.DataAnnotations;

namespace GMS.Entities.Models
{
    public class Seminar
    {
        [Key]
        public int ID { get; set; }
        public string Tema { get; set; }
        public string Predavac { get; set; }
        public DateTime Datum { get; set; }
    }
}
