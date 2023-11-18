using Azure.Core;
using GMS.Data;
using GMS.Entities.Endpoint.Authentication.Get;
using GMS.Entities.Models;
using GMS.Helpers;
using GMS.Helpers.AutentifikacijaAutorizacija;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

namespace FIT_Api_Example.Endpoints.Autentifikacija.Get
{

    [Route("Autentifikacija")]
    public class AutentifikacijaGetEndpoint : MyBaseEndpoint<AutentifikacijaGetRequest, MyAuthInfo>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _authService;
        public AutentifikacijaGetEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }

        [HttpPost("Get")]
        public override async Task<MyAuthInfo> Handle([FromBody] AutentifikacijaGetRequest request, CancellationToken cancellationToken)
        {
            AutentifikacijaToken? autentifikacijaToken = _authService.GetAuthInfo().autentifikacijaToken;

            return new MyAuthInfo(autentifikacijaToken);
        }
    }
}
