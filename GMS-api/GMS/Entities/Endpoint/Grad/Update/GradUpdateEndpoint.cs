using GMS.Controllers.Drzava.Add;
using GMS.Controllers.Grad.Update;
using GMS.Data;
using GMS.Entities.Models;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Endpoint.Grad.Update
{
    [Route("Grad-Update")]
    public class GradUpdateEndpoint : MyBaseEndpoint<GradUpdateRequest, GradUpdateResponse>
    {
        private readonly ApplicationDbContext db;

        public GradUpdateEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPatch]
        public override async Task<GradUpdateResponse> Handle([FromBody] GradUpdateRequest request)
        {
            var grad = db.Grad.Where(x => x.ID == request.ID).FirstOrDefault();

            if(grad == null)
            {
                throw new Exception("Grad ne postoji");
            }

            grad.Naziv = request.Naziv;

           

            db.Entry(grad).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await db.SaveChangesAsync();

            return new GradUpdateResponse
            {
                ID = grad.ID
            };
        }

    }
}
