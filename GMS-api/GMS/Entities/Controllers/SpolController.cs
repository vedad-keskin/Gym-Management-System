using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController] 
    [Route("[controller]/[action]")] 
    public class SpolController : ControllerBase
    {

        private readonly ApplicationDbContext db;
        public SpolController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }




        [HttpGet]

        public object GetAll()
        {
            var sviZapisi = db.Spol.OrderBy(x => x.ID)
                .Select(x => new
                {
                    ID = x.ID,
                    Naziv = x.Naziv
                }
                ).ToList();

            return sviZapisi;
        }

     
        [HttpPost]

        public Spol Add([FromBody] SpolAddVM x)
        {
            var noviZapis = new Spol
            {
                Naziv = x.Naziv
            };

            db.Add(noviZapis);
            db.SaveChanges();
            return noviZapis;
        }



    }
}
