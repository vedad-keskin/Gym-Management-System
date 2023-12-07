using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Dobavljac.Add
{
    [Route("Dobavljac-Add")]

    public class DobavljacAddEndpoint : MyBaseEndpoint<DobavljacAddRequest, DobavljacAddResponse>
    {
        private readonly ApplicationDbContext db;

        public DobavljacAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<DobavljacAddResponse> Handle([FromBody] DobavljacAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Dobavljac
            {
                Naziv = request.Naziv
            };

            db.Dobavljac.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new DobavljacAddResponse
            {
                ID = novi.ID,
                Naziv = novi.Naziv

            };
        }
    }
}
