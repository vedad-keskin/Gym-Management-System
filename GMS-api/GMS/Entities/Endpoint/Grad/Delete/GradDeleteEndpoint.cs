using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Endpoint.Grad.Delete
{
    [Route("Grad-Delete")]
    public class GradDeleteEndpoint : MyBaseEndpoint<GradDeleteRequest,GradDeleteResponse>
    {
        private readonly ApplicationDbContext db;
        public GradDeleteEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpDelete]
        public override async Task<GradDeleteResponse> Handle([FromQuery]GradDeleteRequest request)
        {
            var zapis = db.Grad.Where(x => x.Naziv.ToLower() == request.Naziv.ToLower()).FirstOrDefault();
            // jer nam treba jedan a ne lista ovo uzima prvi ili null ako ga nema 

            if(zapis == null)
            {
                throw new Exception("Nije pronadjen zapis sa nazivom "+request.Naziv);
            }
            db.Remove(zapis);
            await db.SaveChangesAsync();

            return new GradDeleteResponse
            {

            };
        }

    }
}
