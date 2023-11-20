using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Korisnik_Trener.GetAll
{
    [Route("Korisnik_Trener-GetAll")]

    public class Korisnik_TrenerGetAllEndpoint : MyBaseEndpoint<Korisnik_TrenerGetAllRequest, Korisnik_TrenerGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public Korisnik_TrenerGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<Korisnik_TrenerGetAllResponse> Handle([FromQuery] Korisnik_TrenerGetAllRequest request, CancellationToken cancellationToken)
        {
            var korisnici_treneri = await db.Korisnik_Trener
                .Select(x => new KorisnikTrenerGetAllResponseRow
                {
                    KorisnikID = x.KorisnikID,
                    TrenerID = x.TrenerID,
                    DatumiVrijemeOdrzavanja = x.DatumTermina,
                    OdrzanoSati = x.OdrzanoSati


                }).ToListAsync(cancellationToken : cancellationToken);

            return new Korisnik_TrenerGetAllResponse
            {

                KorisnikTrener = korisnici_treneri

            };
        }
    }
}
