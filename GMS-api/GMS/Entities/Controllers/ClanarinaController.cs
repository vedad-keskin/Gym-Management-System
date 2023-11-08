using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ClanarinaController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public ClanarinaController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpPost]
        public Clanarina Add([FromBody] ClanarinaAddVM x)
        {
            var novaClanarina = new Clanarina
            {
                Naziv = x.Naziv,
                Cijena = x.Cijena
            };

            db.Clanarina.Add(novaClanarina);
            db.SaveChanges();
            return novaClanarina;

        }

        [HttpGet]

        public object GetAll()
        {
            var sveClanarine = db.Clanarina
                .Select(x => new
                {
                    Naziv = x.Naziv,
                    Cijena = x.Cijena
                }
                ).ToList();

            return sveClanarine;
        }

    }
}
