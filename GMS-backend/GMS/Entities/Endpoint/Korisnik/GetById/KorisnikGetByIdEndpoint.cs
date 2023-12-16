using GMS.Data;
using GMS.Helpers.Services;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Korisnik.GetById;

[Route("Korisnik-GetById")]
//[MyAuthorization]
public class KorisnikGetByIdEndpoint : MyBaseEndpoint<int, KorisnikGetByIdResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;
    public KorisnikGetByIdEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpGet("{id}")]
    public override async Task<KorisnikGetByIdResponse> Handle(int id, CancellationToken cancellationToken)
    {
        var korisnik = await _applicationDbContext.Korisnik.FindAsync(id);

        var gradovi = _applicationDbContext.Grad.ToList();
        var spolovi = _applicationDbContext.Spol.ToList();
        var teretane = _applicationDbContext.Teretana.ToList();

        if (korisnik is null)
            throw new Exception("Nije nadjen korisnik za id = " + id);

        var grad = gradovi[korisnik.GradID-1];
        var spol = spolovi[korisnik.SpolID-1];
        var teretana = teretane[korisnik.TeretanaID-1];

        var result = new KorisnikGetByIdResponse
        {
            KorisnikID = korisnik.ID,
            Ime = korisnik.Ime,
            Prezime = korisnik.Prezime,
            BrojTelefona = korisnik.BrojTelefona,
            Slika = korisnik.Slika,
            Visina = korisnik.Visina,
            Tezina = korisnik.Tezina,
            Username = korisnik.Username,
            NazivGrada = grad.Naziv,
            NazivSpola = korisnik.Spol.Naziv,
            NazivTeretane = korisnik.Teretana.Naziv,



        };



        return result;
    }
}