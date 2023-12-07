using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Clanarina.GetAll
{
    [Route("Clanarina-GetAll")]

    public class ClanarinaGetAllEndpoint : MyBaseEndpoint<ClanarinaGetAllRequest, ClanarinaGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public ClanarinaGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<ClanarinaGetAllResponse> Handle([FromQuery] ClanarinaGetAllRequest request, CancellationToken cancellationToken)
        {
            var clanarine = await db.Clanarina
                .Select(x => new ClanarinaGetAllResponseRow
                {
                    ID = x.ID,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena,
                    Opis = x.Opis


                }).ToListAsync(cancellationToken : cancellationToken);

            return new ClanarinaGetAllResponse
            {
                Clanarine = clanarine
            };
        }
    }

}
