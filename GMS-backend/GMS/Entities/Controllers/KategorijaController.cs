using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class KategorijaController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public KategorijaController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpPost]

        public Kategorija Add([FromBody] KateogorijaAddVM x)
        {
            var noviZapis = new Kategorija
            {
                Naziv = x.Naziv

            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }

        [HttpGet]

        public object GetAll()
        {
            var sviZapisi = db.Kategorija
                .Select(x => new
                {
                    ID = x.ID,
                    Naziv = x.Naziv
                }
                ).ToList();

            return sviZapisi;
        }
    }
}
