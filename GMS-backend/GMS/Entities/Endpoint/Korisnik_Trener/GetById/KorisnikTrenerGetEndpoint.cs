using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Korisnik_Trener.GetById
{
    [Route("Korisnik-Trener-Get")]

    public class KorisnikTrenerGetEndpoint : MyBaseEndpoint<int, KorisnikTrenerGetResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _authService;

        public KorisnikTrenerGetEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }

        [HttpGet("{id}")]
        public override async Task<KorisnikTrenerGetResponse> Handle(int id, CancellationToken cancellationToken)
        {
            var korisnik = await _applicationDbContext.Korisnik.FindAsync(id);

            if (korisnik is null)
                throw new Exception("Nije nađen korisnik za id = " + id);

            var result = new KorisnikTrenerGetResponse
            {
                KorisnikID = korisnik.ID,
                Ime = korisnik.Ime,
                Prezime = korisnik.Prezime,
                ZakazaniTermini = await _applicationDbContext
                    .Korisnik_Trener.Include("Trener").Include("Korisnik")
                    .Where(x => x.KorisnikID == id)
                    .Select(x => new KorisnikTrenerGetResponseZakazaniTermini
                    {
                        KorisnikID=x.KorisnikID,
                        TrenerID=x.TrenerID,
                        DatumTermina=x.DatumTermina,
                        ZakazanoSati = x.ZakazanoSati

                    })
                    .ToListAsync(cancellationToken)
            };
            return result;
        }
    }
}
