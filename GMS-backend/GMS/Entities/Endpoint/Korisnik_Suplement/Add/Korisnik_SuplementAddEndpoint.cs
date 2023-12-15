using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Korisnik_Suplement.Add
{
    [Route("Korisnik_Suplement-Add")]
    [MyAuthorization]

    public class Korisnik_SuplementAddEndpoint : MyBaseEndpoint<Korisnik_SuplementAddRequest, Korisnik_SuplementAddResponse>
    {
        private readonly ApplicationDbContext db;

        public Korisnik_SuplementAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<Korisnik_SuplementAddResponse> Handle([FromBody]Korisnik_SuplementAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Korisnik_Suplement
            {
                SuplementID=request.SuplementID,
                KorisnikID=request.KorisnikID,
                DatumVrijemeNarudzbe=request.DatumVrijemeNarudzbe,
                Kolicina=request.Kolicina
            };

            db.Korisnik_Suplement.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new Korisnik_SuplementAddResponse
            {
               DatumVrijemeNarudzbe=novi.DatumVrijemeNarudzbe,
               Kolicina=novi.Kolicina
            };
        }
    }
}
