using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.KorisnikSuplement.GetAll
{
    [Route("Korisnik_Suplement-GetAll")]
    [MyAuthorization]

    public class Korisnik_SuplementGetAllEndpoint : MyBaseEndpoint<Korisnik_SuplementGetAllRequest, Korisnik_SuplementGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public Korisnik_SuplementGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<Korisnik_SuplementGetAllResponse> Handle([FromQuery]Korisnik_SuplementGetAllRequest request, CancellationToken cancellationToken)
        {
            var korisniksuplement = await db.Korisnik_Suplement
                .Select(x => new KorisnikSuplementGetAllResponseRow
                {
                    SuplementiID=x.SuplementID,
                    KorisnikID=x.KorisnikID,
                    DatumVrijemeNarudzbe=x.DatumVrijemeNarudzbe,
                    Kolicina=x.Kolicina,
                  
                }).ToListAsync(cancellationToken: cancellationToken);

            return new Korisnik_SuplementGetAllResponse
            {
                KorisnikSuplement = korisniksuplement
            };
        }
    }
}
