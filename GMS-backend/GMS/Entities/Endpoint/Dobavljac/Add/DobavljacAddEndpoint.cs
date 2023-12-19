using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Dobavljac.Add
{
    [Route("Dobavljac-Add")]
    [MyAuthorization]

    public class DobavljacAddEndpoint : MyBaseEndpoint<DobavljacAddRequest, DobavljacAddResponse>
    {
        private readonly ApplicationDbContext db;
        private readonly MyAuthService auth;

        public DobavljacAddEndpoint(ApplicationDbContext db, MyAuthService auth)
        {
            this.db = db;
            this.auth = auth;
        }

        [HttpPost]
        public override async Task<DobavljacAddResponse> Handle([FromBody] DobavljacAddRequest request, CancellationToken cancellationToken)
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
