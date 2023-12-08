using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Kategorija.GetAll
{
    [Route("Kategorija-GetAll")]

    public class KategorijeGetAllEndpoint : MyBaseEndpoint<KategorijaGetAllRequest, KategorijaGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public KategorijeGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<KategorijaGetAllResponse> Handle([FromQuery]KategorijaGetAllRequest request, CancellationToken cancellationToken)
        {
            var kategorije = await db.Kategorija
                .Select(x => new KategorijaGetAllResponseRow
                {
                    ID = x.ID,
                    Naziv = x.Naziv

                }).ToListAsync(cancellationToken: cancellationToken);

            return new KategorijaGetAllResponse
            {
                Kategorije = kategorije
            };
        }
    }
}
