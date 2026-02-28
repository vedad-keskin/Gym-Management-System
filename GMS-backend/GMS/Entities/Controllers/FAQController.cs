using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FAQController : Controller
    {
        private readonly ApplicationDbContext db;
        public FAQController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet]

        public object GetAll()
        {
            var sviZapisi = db.FAQ
                .Select(x => new
                {
                    ID = x.ID,
                    Pitanje = x.Pitanje,
                    Odgovor = x.Odgovor
                }
                ).ToList();

            return sviZapisi;
        }

        [HttpPost]

        public FAQ Add([FromBody] FAQAddVM x)
        {
            var noviZapis = new FAQ
            {
                Pitanje = x.Pitanje,
                Odgovor = x.Odgovor

            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }


    }
}
