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
        public override async Task<AdministratorGetAllResponse> Handle([FromQuery]AdministratorGetAllRequest request)
        {
            var administrator = await db.Administrator
                .Select(x => new AdministratorGetAllResponseRow
                {
                    ID = x.ID,
                    Username=x.Username,
                    Password=x.Password
                    
                }).ToListAsync();

            return new AdministratorGetAllResponse
            {
                Administrator = administrator
            };
        }
    }
}
