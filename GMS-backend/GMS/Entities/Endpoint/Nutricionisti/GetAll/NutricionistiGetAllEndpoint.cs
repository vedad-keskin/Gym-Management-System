using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Nutricionisti.GetAll
{
    [Route("Nutricionisti-GetAll")]

    public class NutricionistiGetAllEndpoint : MyBaseEndpoint<NutricionistiGetAllRequest, NutricionistiGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public NutricionistiGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<NutricionistiGetAllResponse> Handle([FromQuery]NutricionistiGetAllRequest request)
        {
            var nutricionisti = await db.Nutricionist
                .Select(x => new NutricionistiGetAllResponseRow
                {
                    ID = x.ID,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    BrojTelefona = x.BrojTelefona,
                    Slika=x.Slika
                }).ToListAsync();

            return new NutricionistiGetAllResponse
            {
                Nutricionisti = nutricionisti
            };
        }
    }
}
