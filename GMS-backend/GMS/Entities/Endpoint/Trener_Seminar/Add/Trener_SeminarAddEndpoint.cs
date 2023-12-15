using GMS.Data;
using GMS.Entities.Endpoint.Korisnik_Trener.Add;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Trener_Seminar.Add
{
    [Route("Trener_Seminar-Add")]
    [MyAuthorization]

    public class Trener_SeminarAddEndpoint : MyBaseEndpoint<Trener_SeminarAddRequest, Trener_SeminarAddResponse>
    {
        private readonly ApplicationDbContext db;

        public Trener_SeminarAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<Trener_SeminarAddResponse> Handle([FromBody]Trener_SeminarAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Trener_Seminar
            {
                SeminarID=request.SeminarID,
                TrenerID=request.TrenerID
            };

            db.Trener_Seminar.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new Trener_SeminarAddResponse
            {
                
            };
        }
    }
}
