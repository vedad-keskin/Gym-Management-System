using GMS.Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMS.Entities.Endpoint.Korisnik.GetAll
{
    public class KorisnikGetAllResponse
    {
        public List<KorisnikGetAllResponseRow> Korisnici { get; set; }
    }


    public class KorisnikGetAllResponseRow // samo se radi kada je rezultat lista a ne jedan zapis 
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string? Slika { get; set; }

        public string BrojTelefona { get; set; }
        public float Visina { get; set; }
        public float Tezina { get; set; }

        public string NazivGrada { get; set; } 
        public string NazivSpol { get; set; } 
        public string NazivTeretane { get; set; } 

   
    }
}
