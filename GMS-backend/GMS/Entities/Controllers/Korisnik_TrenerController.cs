using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Korisnik_TrenerController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public Korisnik_TrenerController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet]

        public object GetAll()
        {
            var noviZapis = db.Korisnik_Trener.OrderBy(x => x.DatumTermina)
                .Select(x => new
                {
                    Korisnik = x.Korisnik,
                    Trener = x.Trener,
                    DatumTermina = x.DatumTermina,
                    OdrzanoSati = x.OdrzanoSati
                }
                ).ToList();

            return noviZapis;
        }

        [HttpPost]

        public Korisnik_Trener Add([FromBody] Korisnik_TrenerAddVM x)
        {
            var noviZapis = new Korisnik_Trener
            {
                KorisnikID = x.KorisnikID,
                TrenerID = x.TrenerID,
                DatumTermina = x.DatumTermina,
                OdrzanoSati = x.OdrzanoSati

            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }
    }
}
