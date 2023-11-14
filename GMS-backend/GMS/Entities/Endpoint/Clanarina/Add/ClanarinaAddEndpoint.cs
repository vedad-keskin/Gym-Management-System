using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Clanarina.Add
{
    [Route("Clanarina-Add")]

    public class ClanarinaAddEndpoint : MyBaseEndpoint<ClanarinaAddRequest, ClanarinaAddResponse>
    {
        private readonly ApplicationDbContext db;

        public ClanarinaAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<ClanarinaAddResponse> Handle([FromBody]ClanarinaAddRequest request)
        {
            var novi = new Entities.Models.Clanarina
            {
               Naziv=request.Naziv,
               Cijena=request.Cijena,
               Opis=request.Opis
            };

            db.Clanarina.Add(novi);
            await db.SaveChangesAsync();

            return new ClanarinaAddResponse
            {
                ID = novi.ID
            };
        }
    }
}
