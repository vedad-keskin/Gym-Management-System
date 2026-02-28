using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Kategorija.Add
{
    [Route("Kategorija-Add")]
    [MyAuthorization]

    public class KategorijaAddEndpoint : MyBaseEndpoint<KategorijaAddRequest, KategorijaAddResponse>
    {
        private readonly ApplicationDbContext db;

        public KategorijaAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<KategorijaAddResponse> Handle([FromBody]KategorijaAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Kategorija
            {
                Naziv = request.Naziv
            };

            db.Kategorija.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new KategorijaAddResponse
            {
                ID = novi.ID,
                Naziv = novi.Naziv

            };
        }
    }
}
