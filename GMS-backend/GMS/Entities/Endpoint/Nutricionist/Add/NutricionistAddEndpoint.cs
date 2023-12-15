//using GMS.Controllers.Drzava.Add;
using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Nutricionist.Add
{
    [Route("Nutricionist-Add")]
    [MyAuthorization]

    public class NutricionistAddEndpoint : MyBaseEndpoint<NutricionistAddRequest, NutricionistAddResponse>
    {
        private readonly ApplicationDbContext db;

        public NutricionistAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<NutricionistAddResponse> Handle([FromBody]NutricionistAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Nutricionist
            {
                Ime=request.Ime,
                Prezime=request.Prezime,
                Slika=request.Slika,
                BrojTelefona=request.BrojTelefona
            };

            db.Nutricionist.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new NutricionistAddResponse
            {
                ID = novi.ID,
                Ime=novi.Ime,
                Prezime=novi.Prezime,
                Slika=novi.Slika,
                BrojTelefona=novi.BrojTelefona
               
            };
        }
    }
}
