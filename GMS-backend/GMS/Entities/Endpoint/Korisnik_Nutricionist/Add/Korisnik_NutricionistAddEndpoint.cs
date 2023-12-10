using FIT_Api_Example.Helper.Auth;
using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Korisnik_Nutricionist.Add
{
    [Route("Korisnik_Nutricionist-Add")]
    [MyAuthorization]

    public class Korisnik_NutricionistAddEndpoint : MyBaseEndpoint<Korisnik_NutricionistAddRequest, Korisnik_NutricionistAddResponse>
    {
        private readonly ApplicationDbContext db;

        public Korisnik_NutricionistAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<Korisnik_NutricionistAddResponse> Handle([FromBody]Korisnik_NutricionistAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Korisnik_Nutricionist
            {
                KorisnikID=request.KorisnikID,
                NutricionistID=request.NutricionistID,
                DatumTermina=request.DatumTermina,
                OdrzanoSati=request.OdrzanoSati
            };

            db.Korisnik_Nutricionst.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new Korisnik_NutricionistAddResponse
            {
                DatumTermina=novi.DatumTermina,
                OdrzanoSati=novi.OdrzanoSati
            };
        }
    }
}
