using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Nutricionist_Seminar.Add
{
    [Route("Nutricionist_Seminar-Add")]
    [MyAuthorization]

    public class NutricionistSeminarAddEndpoint : MyBaseEndpoint<NutricionistSeminarAddRequest, NutricionistSeminarAddResponse>
    {
        private readonly ApplicationDbContext db;

        public NutricionistSeminarAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<NutricionistSeminarAddResponse> Handle([FromBody] NutricionistSeminarAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Nutricionist_Seminar
            {
                NutricionistID=request.NutricionistID,
                SeminarID=request.SeminarID
            };

            db.Nutricionist_Seminar.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new NutricionistSeminarAddResponse
            {
                NutricionistID=novi.NutricionistID,
                SeminarID=novi.SeminarID
                
            };
        }
    }
}
