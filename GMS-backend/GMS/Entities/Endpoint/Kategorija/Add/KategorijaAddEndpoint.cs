using FIT_Api_Example.Helper.Auth;
using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Kategorija.Add
{
    [Route("Kategorija-Add")]
    [MyAuthorization]

    public class KategorijaAddEndpoint : MyBaseEndpoint<KategorijaAddRequest, KategorijaAddResponse>
    {
        private readonly ApplicationDbContext db;
        private readonly MyAuthService auth;

        public KategorijaAddEndpoint(ApplicationDbContext db, MyAuthService auth)
        {
            this.db = db;
            this.auth = auth;
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
