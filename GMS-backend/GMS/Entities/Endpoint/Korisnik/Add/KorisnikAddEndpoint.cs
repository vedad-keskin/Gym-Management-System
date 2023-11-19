using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Korisnik.Add
{
    [Route("Korisnik-Add")]

    public class KorisnikAddEndpoint : MyBaseEndpoint<KorisnikAddRequest, KorisnikAddResponse>
    {
        private readonly ApplicationDbContext db;

        public KorisnikAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
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
                BrojTelefona=request.BrojTelefona,
                Visina=request.Visina,
                Tezina=request.Tezina,
                NazivGrada=request.NazivGrada,
                NazivSpol=request.NazivSpol,
                NazivTeretane=request.NazivTeretane
            };

            db.Korisnik.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new KorisnikAddResponse
            {
                ID = novi.ID,
                Ime=novi.Ime,
                Prezime=novi.Prezime,
                Username=novi.Username,
                Password=novi.Password,
                Slika=novi.Slika,
                BrojTelefona=novi.BrojTelefona,
                Visina=novi.Visina,
                Tezina=novi.Tezina,
                NazivGrada=novi.NazivGrada,
                NazivSpol=novi.NazivSpol,
                NazivTeretane=novi.NazivTeretane
            };
        }
    }
}
