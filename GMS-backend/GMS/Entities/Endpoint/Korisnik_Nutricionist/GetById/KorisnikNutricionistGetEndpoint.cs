using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Korisnik_Nutricionist.GetById
{
    [Route("Korisnik-Nutricionist-Get")]

    public class KorisnikNutricionistGetEndpoint : MyBaseEndpoint<int, KorisnikNutricionistGetResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _authService;

        public KorisnikNutricionistGetEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }

        [HttpGet("{id}")]
        public override async Task<KorisnikNutricionistGetResponse> Handle(int id, CancellationToken cancellationToken)
        {
            var korisnik = await _applicationDbContext.Korisnik.FindAsync(id);
    
            if (korisnik is null)
                throw new Exception("Nije nađen korisnik za id = " + id);

            var result = new KorisnikNutricionistGetResponse
            {
                KorisnikID = korisnik.ID,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                ZakazaniTermini = await _applicationDbContext
                    .Korisnik_Nutricionst.Include("Nutricionist").Include("Korisnik")
                    .Where(x => x.KorisnikID == id)
                    .Select(x => new KorisnikNutricionistGetResponseZakazaniTermini
                    {
                        KorisnikID = x.KorisnikID,
                        NutricionistID=x.NutricionistID,
                        DatumTermina=x.DatumTermina,
                        ZakazanoSati = x.ZakazanoSati

                    })

                    .ToListAsync(cancellationToken)
            };



            return result;
        }
    }
}
