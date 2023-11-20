using Azure.Core;
using GMS.Data;
using GMS.Entities.Models;
using GMS.Helpers.Services;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GMS.Entities.Endpoint.Authentication.Login;
using Azure;

namespace GMS.Entities.Endpoint.Authentication.Logout;

[Route("Autentifikacija")]
public class AutentifikacijaLogoutEndpoint : MyBaseEndpoint<NoRequest, NoResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;

    public AutentifikacijaLogoutEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpPost("Logout")]
    public override async Task<NoResponse> Handle([FromBody] NoRequest request, CancellationToken cancellationToken)
    {
        AutentifikacijaToken? autentifikacijaToken = _authService.GetAuthInfo().autentifikacijaToken;

        if (autentifikacijaToken == null)
            return new NoResponse();

        _applicationDbContext.Remove(autentifikacijaToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return new NoResponse();
    }


}