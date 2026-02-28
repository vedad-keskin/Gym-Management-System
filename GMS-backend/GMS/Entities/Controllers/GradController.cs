using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController] // ovo se mora
    [Route("[controller]/[action]")]  // putanja kontrolera 
    public class GradController : ControllerBase
    {

        private readonly ApplicationDbContext db;
        public GradController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        //httpGet za dohvatanje
        //httpPost za dodavanje 
        //httpPut za modifikaciju
        //httpDelete za brisanje 
        //httpPatch ako je izmjena samo jednog atributa 


        [HttpGet]

        public object GetAll()
        {
            var sviGradovi = db.Grad.OrderBy(x => x.ID)
                .Select(x => new
                {
                    ID = x.ID,
                    Naziv = x.Naziv
                }
                ).ToList();

            return sviGradovi;
        }

        [HttpGet]

        public object GetSaDodatnimParametromIPretragom(string? naziv) // da mozemo i null
        {
            var sviGradovi = db.Grad.OrderBy(x => x.Naziv)
                .Where(x=> naziv == null || x.Naziv.ToLower().StartsWith(naziv.ToLower()))
                .Select(x => new GradGetVM
                {
                    ID = x.ID,
                    Naziv = x.Naziv
                }
                ).ToList();

            return sviGradovi;
        }

        [HttpPost]

        public object Add_withParameters(string naziv)
        {
            var noviGrad = new Grad
            {
                Naziv = naziv
            };

            db.Add(noviGrad);
            db.SaveChanges();
            return noviGrad;
        }


        [HttpPost]

        public Grad Add([FromBody] GradAddVM x)
        {
            var noviGrad = new Grad
            {
                Naziv = x.Naziv
            };

            db.Add(noviGrad);
            db.SaveChanges();
            return noviGrad;
        }



    }
}
