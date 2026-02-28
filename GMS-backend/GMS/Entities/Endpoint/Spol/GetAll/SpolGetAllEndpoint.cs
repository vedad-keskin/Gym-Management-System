using GMS.Data;
using GMS.Entities.Endpoint.Teretana.GetAll;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Spol.GetAll
{
    [Route("Spol-GetAll")]

    public class SpolGetAllEndpoint : MyBaseEndpoint<SpolGetAllRequest, SpolGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public SpolGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<SpolGetAllResponse> Handle([FromQuery] SpolGetAllRequest request, CancellationToken cancellationToken)
        {
            var spolovi = await db.Spol
               .Select(x => new SpolGetAllResponseRow
               {
                   ID = x.ID,
                   Naziv = x.Naziv

               }).ToListAsync(cancellationToken: cancellationToken);

            return new SpolGetAllResponse
            {
                Spolovi = spolovi
            };
        }
    }
}
