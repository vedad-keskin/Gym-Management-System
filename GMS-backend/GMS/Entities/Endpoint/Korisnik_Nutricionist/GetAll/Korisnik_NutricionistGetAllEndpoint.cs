using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Korisnik_Nutricionist.GetAll
{
    [Route("Korisnik_Nutricionist-GetAll")]

    public class Korisnik_NutricionistGetAllEndpoint : MyBaseEndpoint<Korisnik_NutricionistGetAllRequest, Korisnik_NutricionistGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public Korisnik_NutricionistGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<Korisnik_NutricionistGetAllResponse> Handle([FromQuery]Korisnik_NutricionistGetAllRequest request, CancellationToken cancellationToken)
        {
            var korisniknutricionist = await db.Korisnik_Nutricionst
                .Select(x => new KorisnikNutricionistGetAllResponseRow
                {
                   KorisnikID=x.KorisnikID,
                   NutricionistID=x.NutricionistID,
                   DatumTermina=x.DatumTermina,
                   OdrzanoSati=x.OdrzanoSati

                }).ToListAsync(cancellationToken: cancellationToken);

            return new Korisnik_NutricionistGetAllResponse
            {
                KorisnikNutricionist = korisniknutricionist
            };
        }
    }
}
