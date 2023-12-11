﻿using Azure.Core;
using GMS.Data;
using GMS.Entities.Models;
using GMS.Helpers.Services;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GMS.Helpers.Auth;
using GMS.Entities.Endpoint.Authentication.TwoFOtklkucaj;

namespace FIT_Api_Example.Endpoints.AuthEndpoints.TwoFOtkljucaj;

[Route("Autentifikacija")]

public class AutentifikacijaTwoFOtkljucajEndpoint : MyBaseEndpoint<AutentifikacijaTwoFOtkljucajRequest, NoResponse>
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly MyAuthService _authService;

    public AutentifikacijaTwoFOtkljucajEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
    {
        _applicationDbContext = applicationDbContext;
        _authService = authService;
    }

    [HttpPost("2f-otkljucaj")]
    public override async Task<NoResponse> Handle([FromBody] AutentifikacijaTwoFOtkljucajRequest request, CancellationToken cancellationToken)
    {
        if(!_authService.GetAuthInfo().isLogiran)
        {
            throw new Exception("Niste se logirali.");
        }
        var token = _authService.GetAuthInfo().autentifikacijaToken;

        if (token is null)
            throw new ArgumentException(nameof(token));

        if(request.Kljuc==token.TwoFKey)
        {
            token.IsOtkljucano = true;
            await _applicationDbContext.SaveChanges(cancellationToken);
        }
 
        return new NoResponse();
    }


}