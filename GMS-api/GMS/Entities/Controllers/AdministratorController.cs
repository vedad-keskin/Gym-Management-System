using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdministratorController : ControllerBase
    {

        private readonly ApplicationDbContext db;
        public AdministratorController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet]

        public object GetAll()
        {
            var sviZapisi = db.Korisnik_Trener
                .Select(x => new
                {
                    KorisnikID = x.KorisnikID,
                    TrenerID = x.TrenerID,
                    DatumTermina = x.DatumTermina,
                    OdrzanoSati = x.OdrzanoSati
                }
                ).ToList();

            return sviZapisi;
        }

        [HttpPost]

        public Administrator Add([FromBody] AdministratorAddVM x)
        {
            var noviZapis = new Administrator
            {
                Username = x.Username,
                Password = x.Password

            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }
    }
}
