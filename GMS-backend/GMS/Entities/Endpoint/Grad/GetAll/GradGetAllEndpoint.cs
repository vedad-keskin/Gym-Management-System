using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Grad.GetAll
{
    [Route("Grad-GetAll")]

    public class GradGetAllEndpoint : MyBaseEndpoint<GradGetAllRequest, GradGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public GradGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<GradGetAllResponse> Handle([FromQuery]GradGetAllRequest request, CancellationToken cancellationToken)
        {
            var gradovi = await db.Grad
                .Select(x => new GradGetAllResponseRow
                {
                    ID = x.ID,
                    Naziv = x.Naziv,
                    


                }).ToListAsync(cancellationToken: cancellationToken);

            return new GradGetAllResponse
            {
                Gradovi = gradovi
            };
        }
    }
}
