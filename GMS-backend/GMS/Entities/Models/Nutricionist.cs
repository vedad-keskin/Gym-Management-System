using Microsoft.Extensions.FileProviders;
using System.ComponentModel.DataAnnotations;

namespace GMS.Entities.Models
{
    public class Nutricionist
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        // public IFileInfo Slika { get; set; }
    }
}
