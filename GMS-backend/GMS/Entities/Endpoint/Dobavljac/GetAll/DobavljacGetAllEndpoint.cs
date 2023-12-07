using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Dobavljac.GetAll
{
    [Route("Dobavljac-GetAll")]

    public class DobavljacGetAllEndpoint : MyBaseEndpoint<DobavljacGetAllRequest, DobavljacGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public DobavljacGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<DobavljacGetAllResponse> Handle([FromQuery]DobavljacGetAllRequest request, CancellationToken cancellationToken)
        {
            var dobavljaci = await db.Dobavljac
               .Select(x => new DobavljacGetAllResponseRow
               {
                   ID = x.ID,
                   Naziv = x.Naziv

               }).ToListAsync(cancellationToken: cancellationToken);

            return new DobavljacGetAllResponse
            {
                Dobavljaci = dobavljaci
            };
        }
    }
}
