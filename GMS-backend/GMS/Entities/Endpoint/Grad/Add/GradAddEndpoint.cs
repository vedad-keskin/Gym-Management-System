using GMS.Controllers.Drzava.Add;
using GMS.Data;
using GMS.Entities.Models;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Endpoint.Grad.Add
{
    [Route("Grad-Add")]
    public class GradAddEndpoint : MyBaseEndpoint<GradAddRequest, GradAddResponse>
    {
        private readonly ApplicationDbContext db;

        public GradAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<GradAddResponse> Handle([FromBody] GradAddRequest request)
        {
            var novi = new Entities.Models.Grad
            {
                Naziv = request.Naziv
            };

            db.Grad.Add(novi);
            await db.SaveChangesAsync();

            return new GradAddResponse {
                ID = novi.ID
            };
        }

    }
}
