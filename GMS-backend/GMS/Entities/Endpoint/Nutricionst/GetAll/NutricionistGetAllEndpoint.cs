using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Nutricionist.GetAll
{
    [Route("Nutricionist-GetAll")]

    public class NutricionistGetAllEndpoint : MyBaseEndpoint<NutricionistGetAllRequest, NutricionistGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public NutricionistGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<NutricionistGetAllResponse> Handle([FromQuery]NutricionistGetAllRequest request, CancellationToken cancellationToken)
        {
            var nutricionisti = await db.Nutricionist
                .Select(x => new NutricionistiGetAllResponseRow
                {
                    ID = x.ID,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    BrojTelefona = x.BrojTelefona,
                    Slika=x.Slika
                }).ToListAsync(cancellationToken: cancellationToken);

            return new NutricionistGetAllResponse
            {
                Nutricionisti = nutricionisti
            };
        }
    }
}
