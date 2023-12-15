using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Nutricionist_Seminar.Add
{
    [Route("Nutricionist_Seminar-Add")]
    [MyAuthorization]

    public class Nutricionist_SeminarAddEndpoint : MyBaseEndpoint<Nutricionist_SeminarAddRequest, Nutricionist_SeminarAddResponse>
    {
        private readonly ApplicationDbContext db;

        public Nutricionist_SeminarAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<Nutricionist_SeminarAddResponse> Handle([FromBody]Nutricionist_SeminarAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Nutricionist_Seminar
            {
                NutricionistID=request.NutricionistID,
                SeminarID=request.SeminarID
            };

            db.Nutricionist_Seminar.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new Nutricionist_SeminarAddResponse
            {
                NutricionistID=novi.NutricionistID,
                SeminarID=novi.SeminarID
            };
        }
    }
}
