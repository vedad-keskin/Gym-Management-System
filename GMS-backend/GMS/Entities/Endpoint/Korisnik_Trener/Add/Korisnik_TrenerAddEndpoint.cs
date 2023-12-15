using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Korisnik_Trener.Add
{
    [Route("Korisnik_Trener-Add")]
    [MyAuthorization]

    public class Korisnik_TrenerAddEndpoint : MyBaseEndpoint<Korisnik_TrenerAddRequest, Korisnik_TrenerAddResponse>
    {
        private readonly ApplicationDbContext db;

        public Korisnik_TrenerAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<Korisnik_TrenerAddResponse> Handle([FromBody]Korisnik_TrenerAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Korisnik_Trener
            {
                KorisnikID = request.KorisnikID,
                TrenerID=request.TrenerID,
                DatumTermina = request.DatumTermina,
                OdrzanoSati = request.OdrzanoSati
            };

            db.Korisnik_Trener.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new Korisnik_TrenerAddResponse
            {
                DatumTermina = novi.DatumTermina,
                OdrzanoSati = novi.OdrzanoSati
            };
        }
    }
}
