using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TrenerController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public TrenerController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet]

        public object GetAll()
        {
            var sviZapisi = db.Trener
                .Select(x => new
                {
                    ID = x.ID,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    BrojTelefona = x.BrojTelefona
                }
                ).ToList();

            return sviZapisi;
        }

        [HttpPost]

        public Trener Add([FromBody] TrenerAddVM x)
        {
            var noviZapis = new Trener
            {
                 Ime = x.Ime,
                 Prezime = x.Prezime,
                 BrojTelefona = x.BrojTelefona

            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }


    }
}
