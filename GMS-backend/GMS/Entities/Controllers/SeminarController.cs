using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SeminarController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public SeminarController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }
        [HttpPost]

        public Seminar Add([FromBody] SeminarAddVM x)
        {
            var noviZapis = new Seminar
            {
                Tema = x.Tema,
                Predavac = x.Predavac,
                Datum = x.Datum

            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }

        [HttpGet]

        public object GetAll()
        {
            var sviZapisi = db.Seminar
                .Select(x => new
                {
                    Tema = x.Tema,
                    Predavac = x.Predavac,
                    Datum = x.Datum
                }
                ).ToList();

            return sviZapisi;
        }

    }
}
