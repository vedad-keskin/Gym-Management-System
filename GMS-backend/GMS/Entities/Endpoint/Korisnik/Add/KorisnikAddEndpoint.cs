using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Korisnik.Add
{
    [Route("Korisnik-Add")]
    [MyAuthorization]

    public class KorisnikAddEndpoint : MyBaseEndpoint<KorisnikAddRequest, KorisnikAddResponse>
    {
        private readonly ApplicationDbContext db;
        private readonly MyAuthService auth;

        public KorisnikAddEndpoint(ApplicationDbContext db, MyAuthService auth)
        {
            this.db = db;
            this.auth = auth;
        }

        [HttpPost]
        public override async Task<KorisnikAddResponse> Handle([FromBody]KorisnikAddRequest request, CancellationToken cancellationToken)
        {
            
            var novi = new Entities.Models.Korisnik
            {
                Ime=request.Ime,
                Prezime=request.Prezime,
                Username=request.Username,
                Password=request.Password,
                Slika=request.Slika,
                Tezina=request.Tezina,
                Visina=request.Visina,
                BrojTelefona=request.BrojTelefona,
                TeretanaID=request.TeretanaID,
                SpolID=request.SpolID,
                GradID=request.GradID
            };

            db.Korisnik.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new KorisnikAddResponse
            {
                ID=novi.ID,
                Ime=novi.Ime,
                Prezime=novi.Prezime,
                Username=novi.Username,
                Password=novi.Password,
            };
        }
    }
}
