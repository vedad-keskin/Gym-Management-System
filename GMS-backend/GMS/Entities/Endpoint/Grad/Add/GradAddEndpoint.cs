using GMS.Data;
using GMS.Entities.Endpoint.Grad.Add;
using GMS.Helpers;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Endpoint.Grad.Add
{
    [Route("Grad-Add")]
    public class GradAddEndpoint : MyBaseEndpoint<GradAddRequest, GradAddResponse>
    {
        private readonly ApplicationDbContext db;
        private readonly MyAuthService auth;

        public GradAddEndpoint(ApplicationDbContext db, MyAuthService auth)
        {
            this.db = db;
            this.auth = auth;
        }

        [HttpPost]
        public override async Task<GradAddResponse> Handle([FromBody] GradAddRequest request, CancellationToken cancellationToken)
        {
            //if (!auth.JelLogiran())
            //{
            //    throw new Exception("Niste se logirali");
            //}

            //KorisnickiNalog korisnickiNalog = auth.GetAuthInfo().korisnickiNalog!;
            //if (!(korisnickiNalog.isAdministrator))
            //{
            //    throw new Exception("Niste ostvarili pravo pristupa");
            //}

            var novi = new Entities.Models.Grad
            {
                Naziv = request.Naziv
            };

            db.Grad.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new GradAddResponse
            {
                ID = novi.ID,
                Naziv = novi.Naziv
            };
        }

    }
}
