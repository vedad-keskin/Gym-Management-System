using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Seminar.Edit
{
    [Route("Seminar-Edit")]
    [MyAuthorization]

    public class SeminariEditEndpoint : MyBaseEndpoint<SeminariEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public SeminariEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]SeminariEditRequest request, CancellationToken cancellationToken)
        {
            Models.Seminar? seminar;
            if (request.ID == 0)
            {
                seminar = new Models.Seminar();
                db.Add(seminar);


            }
            else
            {
                seminar = db.Seminar.FirstOrDefault(s => s.ID == request.ID);
                if (seminar == null)
                    throw new Exception("pogresan ID");
            }

            seminar.Tema = request.Tema.RemoveTags();
            seminar.Predavac = request.Predavac.RemoveTags();
            seminar.Datum = request.Datum;
            

            await db.SaveChangesAsync(cancellationToken);

            return seminar.ID;
        }
    }
}
