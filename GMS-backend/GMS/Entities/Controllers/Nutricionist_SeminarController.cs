using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Nutricionist_SeminarController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public Nutricionist_SeminarController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpPost]

        public Nutricionist_Seminar Add([FromBody] Nutricionist_SeminarAddVM x)
        {
            var noviZapis = new Nutricionist_Seminar
            {
                NutricionistID = x.NutricionistID,
                SeminarID = x.SeminarID

            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }
        [HttpGet]

        public object GetAll()
        {
            var noviZapis = db.Nutricionist_Seminar
                .Select(x => new
                {
                    Nutricionist = x.Nutricionist,
                    Seminar = x.Seminar
                }
                ).ToList();

            return noviZapis;
        }
    }
}
