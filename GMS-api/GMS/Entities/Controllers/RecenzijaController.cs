using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class RecenzijaController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public RecenzijaController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpPost]

        public Recenzija Add([FromBody] RecenzijaAddVM x)
        {
            var noviZapis = new Recenzija
            {
                Ime = x.Ime,
                Prezime = x.Prezime,
                Zanimanje = x.Zanimanje,
                Tekst = x.Tekst
                
            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }

        [HttpGet]

        public object GetAll()
        {
            var sviZapisi = db.Recenzija
                .Select(x => new
                {
                    ID = x.ID,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Zanimanje = x.Zanimanje,
                    Tekst = x.Tekst
                }
                ).ToList();
            return sviZapisi;
        }

        }
    }
