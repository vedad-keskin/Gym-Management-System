using GMS.Data;
using GMS.Entities.Endpoint.Recenzije.GetAll;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Endpoint.Recenzije.GetAll
{
    [Route("Recenzije-GetAll")]

    public class RecenzijeGetAllEndpoint : MyBaseEndpoint<RecenzijeGetAllRequest, RecenzijeGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public RecenzijeGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<RecenzijeGetAllResponse> Handle([FromQuery] RecenzijeGetAllRequest request)
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
                 }).ToListAsync();

            return new RecenzijeGetAllResponse
            {
                Recenzije = recenzija
            };
        }
    }
}
