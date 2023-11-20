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

        [HttpPost]
        public override async Task<ClanarinaAddResponse> Handle([FromBody] ClanarinaAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Clanarina
            {
                Naziv = request.Naziv,
                Cijena = request.Cijena,
                Opis = request.Opis
            };

            db.Clanarina.Add(novi);
            await db.SaveChangesAsync(cancellationToken : cancellationToken);

            return new ClanarinaAddResponse
            {
                ID = novi.ID,
                Naziv = novi.Naziv,
                Cijena = novi.Cijena,
                Opis = novi.Opis


            };
        }
    }
}
