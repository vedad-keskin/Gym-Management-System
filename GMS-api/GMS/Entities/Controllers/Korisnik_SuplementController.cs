using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Korisnik_SuplementController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public Korisnik_SuplementController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpPost]
        public Korisnik_Suplement Add([FromBody] Korisnik_SuplementAddVM x)
        {
            var noviZapis = new Korisnik_Suplement
            {
                KorisnikID = x.KorisnikID,
                SuplementID = x.SuplementID,
                DatumVrijemeNarudzbe = x.DatumVrijemeNarudzbe,
                Kolicina = x.Kolicina

            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }

        [HttpGet]

        public object GetAll()
        {
            var sviZapisi = db.Korisnik_Suplement.Include("Korisnik").Include("Suplement")
                .Select(x => new
                {
                    Korisnik = x.Korisnik,
                    Suplement = x.Suplement,
                    DatumVrijemeNarudzbe = x.DatumVrijemeNarudzbe,
                    Kolicina = x.Kolicina
                }
                ).ToList();

            return sviZapisi;
        }

    }
}
