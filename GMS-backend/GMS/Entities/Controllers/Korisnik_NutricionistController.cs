using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Korisnik_NutricionistController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public Korisnik_NutricionistController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpPost]

        public Korisnik_Nutricionist Add([FromBody] Korisnik_NutricionistAddVM x)
        {
            var noviZapis = new Korisnik_Nutricionist
            {
                KorisnikID = x.KorisnikID,
                NutricionistID = x.NutricionistID,
                DatumTermina = x.DatumTermina

            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }

        [HttpGet]

        public object GetAll()
        {
            var noviZapis = db.Korisnik_Nutricionst.OrderBy(x => x.DatumTermina)
                .Select(x => new
                {
                    Korisnik = x.Korisnik,
                    Nutricionist = x.Nutricionist,
                    DatumTermina = x.DatumTermina
                }
                ).ToList();

            return noviZapis;
        }
    }
}
