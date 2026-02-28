using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Trener_SeminarController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public Trener_SeminarController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpPost]

        public Trener_Seminar Add([FromBody] Trener_SeminarAddVM x)
        {
            var noviZapis = new Trener_Seminar
            {
                TrenerID = x.TrenerID,
                SeminarID = x.SeminarID,

            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }

        [HttpGet]

        public object GetAll()
        {
            var noviZapis = db.Trener_Seminar
                .Select(x => new
                {
                    Trener = x.Trener,
                    Seminar = x.Seminar,
                }
                ).ToList();

            return noviZapis;
        }
    }
}
