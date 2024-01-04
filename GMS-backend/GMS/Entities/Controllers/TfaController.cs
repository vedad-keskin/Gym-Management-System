using GMS.Data;
using GMS.Entities.Models;
using GMS.Entities.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TfaController : ControllerBase
    {
        private readonly ApplicationDbContext db;
        public TfaController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet]

        public object GetAll()
        {
            var sviZapisi = db.AutentifikacijaToken
                .Select(x => new
                {
                    ID = x.KorisnickiNalogId,
                    TwoFKey = x.TwoFKey
                }
                ).ToList();

            return sviZapisi;
        }
    }
}
