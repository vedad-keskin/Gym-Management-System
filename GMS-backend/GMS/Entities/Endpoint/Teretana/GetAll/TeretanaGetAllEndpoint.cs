using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Teretana.GetAll
{
    [Route("Teretana-GetAll")]

    public class TeretanaGetAllEndpoint : MyBaseEndpoint<TeretanaGetAllRequest, TeretanaGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public TeretanaGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<TeretanaGetAllResponse> Handle([FromQuery]TeretanaGetAllRequest request, CancellationToken cancellationToken)
        {
            var teretane = await db.Teretana
               .Select(x => new TeretanaGetAllResponseRow
               {
                   ID = x.ID,
                   Naziv=x.Naziv,
                   Adresa=x.Adresa,
                   GradID=x.GradID

               }).ToListAsync(cancellationToken: cancellationToken);

            return new TeretanaGetAllResponse
            {
                Teretane = teretane
            };
        }
    }
}
