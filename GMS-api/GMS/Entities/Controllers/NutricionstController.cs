using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NutricionstController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public NutricionstController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpPost]

        public Nutricionist Add([FromBody] NutricionstAddVM x)
        {
            var noviZapis = new Nutricionist
            {
                Ime = x.Ime,
                Prezime = x.Prezime,
                BrojTelefona = x.BrojTelefona

            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }

        [HttpGet]

        public object GetAll()
        {
            var sviZapisi = db.Nutricionist
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
    }
}
