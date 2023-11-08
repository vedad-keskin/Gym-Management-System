using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")] 
    public class Korisnik_ClanarinaController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public Korisnik_ClanarinaController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }


        [HttpPost]
        public Korisnik_Clanarina Add([FromBody] Korisnik_ClanarinaAddVM x)
        {
            var novaKorisnikClanarina = new Korisnik_Clanarina
            {
                KorisnikID= x.KorisnikID,
                ClanarinaID = x.ClanarinaID,
                DatumUplate = x.DatumUplate,
                DatumIsteka = x.DatumIsteka
            };

            db.Korisnik_Clanarina.Add(novaKorisnikClanarina);
            db.SaveChanges();
            return novaKorisnikClanarina;

        }

        [HttpGet]

        public object GetAll()
        {
            var sviKorisniciClanarine = db.Korisnik_Clanarina.Include("Korisnik").Include("Clanarina")
                .Select(x => new
                {
                    Korisnik = x.Korisnik,
                    Clanarina = x.Clanarina,
                    DatumUplate = x.DatumUplate,
                    DatumIsteka = x.DatumIsteka,
                }
                ).ToList();

            return sviKorisniciClanarine;
        }

    }
}
