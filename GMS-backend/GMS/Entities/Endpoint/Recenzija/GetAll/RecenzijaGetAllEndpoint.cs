using GMS.Data;
using GMS.Entities.Endpoint.Recenzija.GetAll;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Endpoint.Recenzija.GetAll
{
    [Route("Recenzija-GetAll")]

    public class RecenzijaGetAllEndpoint : MyBaseEndpoint<RecenzijaGetAllRequest, RecenzijaGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public RecenzijaGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<RecenzijaGetAllResponse> Handle([FromQuery] RecenzijaGetAllRequest request, CancellationToken cancellationToken)
        {
            var recenzija = await db.Recenzija
                 .Select(x => new RecenzijeGetAllResponseRow
                 {
                     ID = x.ID,
                     Ime = x.Ime,
                     Prezime = x.Prezime,
                     Zanimanje = x.Zanimanje,
                     Tekst = x.Tekst,
                     Slika = x.Slika
                 }).ToListAsync(cancellationToken: cancellationToken);

            return new RecenzijaGetAllResponse
            {
                Recenzije = recenzija
            };
        }
    }
}
