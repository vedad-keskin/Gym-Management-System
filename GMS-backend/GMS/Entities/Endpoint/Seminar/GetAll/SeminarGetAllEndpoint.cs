using FIT_Api_Example.Helper.Auth;
using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Seminar.GetAll
{
    [Route("Seminar-GetAll")]
    [MyAuthorization]

    public class SeminariGetAllEndpoint : MyBaseEndpoint<SeminarGetAllRequest, SeminarGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public SeminariGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<SeminarGetAllResponse> Handle([FromQuery]SeminarGetAllRequest request, CancellationToken cancellationToken)
        {
            var seminari = await db.Seminar
                 .Select(x => new SeminarGetAllResponseRow
                 {
                     ID = x.ID,
                     Predavac=x.Predavac,
                     Datum=x.Datum,
                     Tema=x.Tema
                  
                 }).ToListAsync(cancellationToken: cancellationToken);

            return new SeminarGetAllResponse
            {
                Seminari = seminari
            };
        }
    }
}
