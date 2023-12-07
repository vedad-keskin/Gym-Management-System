using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Clanarina.Add
{
    [Route("Clanarina-Add")]

    public class ClanarinaAddEndpoint : MyBaseEndpoint<ClanarinaAddRequest, ClanarinaAddResponse>
    {
        private readonly ApplicationDbContext db;
        private readonly MyAuthService auth;

        public ClanarinaAddEndpoint(ApplicationDbContext db, MyAuthService auth)
        {
            this.db = db;
            this.auth = auth;
        }

        [HttpPost]
        public override async Task<ClanarinaAddResponse> Handle([FromBody] ClanarinaAddRequest request, CancellationToken cancellationToken)
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

            var novi = new Entities.Models.Clanarina
            {
                Naziv = request.Naziv,
                Cijena = request.Cijena,
                Opis = request.Opis
            };

            db.Clanarina.Add(novi);
            await db.SaveChangesAsync(cancellationToken : cancellationToken);

            return new ClanarinaAddResponse
            {
                ID = novi.ID,
                Naziv = novi.Naziv,
                Cijena = novi.Cijena,
                Opis = novi.Opis


            };
        }
    }
}
