using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Treneri.GetAll
{
    [Route("Treneri-GetAll")]

    public class TreneriGetAllEndpoint : MyBaseEndpoint<TreneriGetAllRequest, TreneriGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public TreneriGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<TreneriGetAllResponse> Handle([FromQuery]TreneriGetAllRequest request)
        {
            var treneri = await db.Trener
                .Select(x => new TreneriGetAllResponseRow
                {
                    ID = x.ID,
                    Ime=x.Ime,
                    Prezime=x.Prezime,
                    BrojTelefona=x.BrojTelefona
                }).ToListAsync();

            return new TreneriGetAllResponse
            {
                Treneri = treneri
            };
        }
    }
}
