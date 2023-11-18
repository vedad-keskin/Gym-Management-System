using Azure.Core;
using GMS.Data;
using GMS.Entities.Models;
using GMS.Helpers.Services;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GMS.Entities.Endpoint.Authentication.Login;

namespace FIT_Api_Example.Endpoints.AuthEndpoints.Login;

[Route("Autentifikacija")]
public class AutentifikacijaLoginEndpoint : MyBaseEndpoint<AutenfikacijaLoginRequest, MyAuthInfo>
{
    private readonly ApplicationDbContext _applicationDbContext;

    public AutentifikacijaLoginEndpoint(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    [HttpPost("Login")]
    public override async Task<MyAuthInfo> Handle([FromBody] AutenfikacijaLoginRequest request, CancellationToken cancellationToken)
    {
        //1- provjera logina
        KorisnickiNalog? logiraniKorisnik = await _applicationDbContext.KorisnickiNalog
            .FirstOrDefaultAsync(k =>
                k.Username == request.Username && k.Password == request.Password, cancellationToken);

        if (logiraniKorisnik == null)
        {
            //pogresan username i password
            return new MyAuthInfo(null);
        }

        //2- generisati random string
        string randomString = TokenGenerator.Generate(10);

        //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
        var noviToken = new AutentifikacijaToken()
        {
            ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
            vrijednost = randomString,
            korisnickiNalog = logiraniKorisnik,
            vrijemeEvidentiranja = DateTime.Now
        };

        _applicationDbContext.Add(noviToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        //4- vratiti token string
        return new MyAuthInfo(noviToken);
    }


}