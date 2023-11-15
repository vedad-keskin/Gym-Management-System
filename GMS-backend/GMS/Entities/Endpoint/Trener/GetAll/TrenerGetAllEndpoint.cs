using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Trener.GetAll
{
    [Route("Trener-GetAll")]

    public class TrenerGetAllEndpoint : MyBaseEndpoint<TrenerGetAllRequest, TrenerGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public TrenerGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<TrenerGetAllResponse> Handle([FromQuery]TrenerGetAllRequest request, CancellationToken cancellationToken)
        {
            var treneri = await db.Trener
                .Select(x => new TreneriGetAllResponseRow
                {
                    ID = x.ID,
                    Ime=x.Ime,
                    Prezime=x.Prezime,
                    BrojTelefona=x.BrojTelefona,
                    Slika=x.Slika
                }).ToListAsync(cancellationToken : cancellationToken);

            return new TrenerGetAllResponse
            {
                Treneri = treneri
            };
        }
    }
}
