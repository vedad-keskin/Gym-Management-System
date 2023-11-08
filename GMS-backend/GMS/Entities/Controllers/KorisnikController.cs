using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KorisnikController : ControllerBase
    {

        private readonly ApplicationDbContext db;

        public KorisnikController(ApplicationDbContext dbContext)
        {
            this.db = dbContext;
        }

        [HttpPost]

        public Korisnik Add([FromBody] KorisnikAddVM x)
        {
            var noviZapis = new Korisnik
            {
                Ime = x.Ime,
                Prezime = x.Prezime,
                Username = x.Username,
                Password = x.Password,
                // Slika = x.Slika,
                BrojTelefona = x.BrojTelefona,
                Tezina = x.Tezina,
                Visina = x.Visina,
                GradID = x.GradID,
                SpolID = x.SpolID,
                TeretanaID = x.TeretanaID
            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }

        [HttpGet]

        public object GetAll()
        {
            var sviKorisnici = db.Korisnik.Include("Spol").Include("Grad").Include("Teretana").OrderBy(x => x.ID)
                .Select(x => new
                {
                    ID = x.ID,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Username = x.Username,
                    Password = x.Password,
                    // Slika = x.Slika,
                    BrojTelefona = x.BrojTelefona,
                    Visina = x.Visina,
                    Tezina = x.Tezina,
                    Grad = x.Grad,
                    Spol = x.Spol,
                    Teretana = x.Teretana
                }
                ).AsQueryable();


            return sviKorisnici.ToList();
        }

        
    }
}
