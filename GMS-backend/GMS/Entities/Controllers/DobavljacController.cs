using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DobavljacController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public DobavljacController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpPost]

        public Dobavljac Add([FromBody] DobavljacAddVM x)
        {
            var noviZapis = new Dobavljac
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
            var sviZapisi = db.Dobavljac
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
