using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Korisnik.GetAll
{
    [Route("Korisnik-GetAll")]

    public class KorisnikGetAllEndpoint : MyBaseEndpoint<KorisnikGetAllRequest, KorisnikGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public KorisnikGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<KorisnikGetAllResponse> Handle([FromQuery] KorisnikGetAllRequest request, CancellationToken cancellationToken)
        {
            var korisnici = await db.Korisnik
                .Select(x => new KorisnikGetAllResponseRow
                {
                   ID = x.ID,
                   Ime = x.Ime,
                   Prezime = x.Prezime,
                   Username = x.Username,
                   Password = x.Password,
                   Slika = x.Slika,
                   NazivGrada = x.Grad.Naziv,
                   NazivSpol = x.Spol.Naziv,
                   NazivTeretane = x.Teretana.Naziv,
                   BrojTelefona = x.BrojTelefona,
                   Tezina = x.Tezina,
                   Visina = x.Visina

                }).ToListAsync(cancellationToken : cancellationToken);

            return new KorisnikGetAllResponse
            {
                Korisnici = korisnici
            };

        }
    }
}
