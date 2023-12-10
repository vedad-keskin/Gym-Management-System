using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Administrator.GetAll
{
    [Route("Administrator-GetAll")]

    public class AdministratorGetAllEndpoint : MyBaseEndpoint<AdministratorGetAllRequest, AdministratorGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public AdministratorGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<AdministratorGetAllResponse> Handle([FromQuery] AdministratorGetAllRequest request, CancellationToken cancellationToken)
        {
            var administratori = await db.Administrator
                .Select(x => new AdministratorGetAllResponseRow
                {
                    ID = x.ID,
                    Username = x.Username,
                    Password = x.Password,
                    Ime = x.Ime,
                    Prezime = x.Prezime

                }).ToListAsync(cancellationToken: cancellationToken);

            return new AdministratorGetAllResponse
            {
                Administratori = administratori
            };
        }
    }
}
