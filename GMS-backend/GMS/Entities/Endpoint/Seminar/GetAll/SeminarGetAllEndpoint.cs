using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Seminar.GetAll
{
    [Route("Seminar-GetAll")]

    public class SeminarGetAllEndpoint : MyBaseEndpoint<SeminarGetAllRequest, SeminarGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public SeminarGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<SeminarGetAllResponse> Handle([FromQuery]SeminarGetAllRequest request, CancellationToken cancellationToken)
        {
            var seminar = await db.Seminar
                 .Select(x => new SeminarGetAllResponseRow
                 {
                     ID = x.ID,
                     Predavac=x.Predavac,
                     Datum=x.Datum,
                     Tema=x.Tema
                  
                 }).ToListAsync(cancellationToken: cancellationToken);

            return new SeminarGetAllResponse
            {
                Seminar = seminar
            };
        }
    }
}
