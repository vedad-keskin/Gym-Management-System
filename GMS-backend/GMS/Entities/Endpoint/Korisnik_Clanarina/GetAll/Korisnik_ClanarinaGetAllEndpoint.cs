using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Korisnik_Clanarina.GetAll
{
    [Route("Korisnik_Clanarina-GetAll")]

    public class Korisnik_ClanarinaGetAllEndpoint : MyBaseEndpoint<Korisnik_ClanarinaGetAllRequest, Korisnik_ClanarinaGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public Korisnik_ClanarinaGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<Korisnik_ClanarinaGetAllResponse> Handle([FromQuery]Korisnik_ClanarinaGetAllRequest request, CancellationToken cancellationToken)
        {
            var korisnikclanarina = await db.Korisnik_Clanarina
                .Select(x => new KorisnikClanarinaGetAllResponseRow
                {
                  ClanarinaID=x.ClanarinaID,
                  KorisnikID=x.KorisnikID,
                  DatumUplate=x.DatumUplate,
                  DatumIsteka=x.DatumIsteka

                }).ToListAsync(cancellationToken : cancellationToken);

            return new Korisnik_ClanarinaGetAllResponse
            {
                Korisnik_Clanarina = korisnikclanarina
            };
        }
    }
}
