using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Administrator.Add
{
    [Route("Administrator-Add")]

    public class AdministratorAddEndpoint : MyBaseEndpoint<AdministratorAddRequest, AdministratorAddResponse>
    {
        private readonly ApplicationDbContext db;
        private readonly MyAuthService auth;

        public AdministratorAddEndpoint(ApplicationDbContext db, MyAuthService auth)
        {
            this.db = db;
            this.auth = auth;
        }

        [HttpPost]
        public async override Task<AdministratorAddResponse> Handle([FromBody]AdministratorAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Administrator
            {
                Ime=request.Ime,
                Prezime=request.Prezime,
                Username=request.Username,
                Password=request.Password
            };

            db.Administrator.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new AdministratorAddResponse
            {
                ID = novi.ID,
                Ime=novi.Ime,
                Prezime=novi.Prezime
            };
        }
    }
}
