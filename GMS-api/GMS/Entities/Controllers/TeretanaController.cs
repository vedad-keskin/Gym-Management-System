using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TeretanaController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public TeretanaController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet]

        public object GetAll()
        {
            var sviZapisi = db.Teretana.OrderBy(x => x.Naziv).Include("Grad")
                .Select(x => new
                {
                    ID = x.ID,
                    Naziv = x.Naziv,
                    Grad = x.Grad,
                    Adresa = x.Adresa
                }
                ).ToList();

            return sviZapisi;
        }


        [HttpPost]

        public Teretana Add([FromBody] TeretanaAddVM x)
        {
            var noviZapis = new Teretana
            {
                Naziv = x.Naziv,
                Adresa = x.Adresa,
                GradID = x.GradID

            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }


    }
}
