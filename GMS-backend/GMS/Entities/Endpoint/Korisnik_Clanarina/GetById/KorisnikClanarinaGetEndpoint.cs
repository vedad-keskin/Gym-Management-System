using GMS.Data;
using GMS.Helpers.Services;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Korisnik_Clanarina.GetById;

[Route("Korisnik-Clanarina-Get")]
//[MyAuthorization]
public class KorisnikClanarinaGetEndpoint : MyBaseEndpoint<int, KorisnikClanarinaGetResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;
    public KorisnikClanarinaGetEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpGet("{id}")]
    public override async Task<KorisnikClanarinaGetResponse> Handle(int id, CancellationToken cancellationToken)
    {
        var korisnik = await _applicationDbContext.Korisnik.FindAsync(id);

        if (korisnik is null)
            throw new Exception("Nije nadjen korisnik za id = " + id);

        var result = new KorisnikClanarinaGetResponse
        {
            KorisnikID = korisnik.ID,
            Ime = korisnik.Ime,
            Prezime = korisnik.Prezime,
            UplaceneClanarine = await _applicationDbContext
                .Korisnik_Clanarina.Include("Clanarina").Include("Korisnik")
                .Where(x => x.KorisnikID == id)
                .Select(x => new KorisnikClanarineGetResponseUplaceneClanarine
                {
                    KorisnikID = x.KorisnikID,
                    ClanarinaID = x.ClanarinaID,
                    DatumUplate = x.DatumUplate,
                    DatumIsteka = x.DatumIsteka,
                    NazivClanarine = x.Clanarina.Naziv,
                    Cijena = x.Clanarina.Cijena
                })
                .ToListAsync(cancellationToken)
        };



        return result;
    }
}