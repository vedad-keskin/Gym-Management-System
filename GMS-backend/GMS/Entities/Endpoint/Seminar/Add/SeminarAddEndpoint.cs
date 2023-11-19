using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Seminar.Add
{
    [Route("Seminar-Add")]

    public class SeminarAddEndpoint : MyBaseEndpoint<SeminarAddRequest, SeminarAddResponse>
    {
        private readonly ApplicationDbContext db;

        public SeminarAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<SeminarAddResponse> Handle([FromBody]SeminarAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Seminar
            {
                Predavac=request.Predavac,
                Datum=request.Datum,
                Tema=request.Tema
            };

            db.Seminar.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new SeminarAddResponse
            { 
                ID = novi.ID,
                Predavac=novi.Predavac,
                Datum=novi.Datum,
                Tema=novi.Tema
                
            };
        }
    }
}
