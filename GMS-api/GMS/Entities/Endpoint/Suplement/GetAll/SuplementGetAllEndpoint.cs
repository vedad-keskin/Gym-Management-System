using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Suplement.GetAll
{
    [Route("Suplement-GetAll")]

    public class SuplementGetAllEndpoint : MyBaseEndpoint<SuplementGetAllRequest, SuplementGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public SuplementGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<SuplementGetAllResponse> Handle([FromQuery] SuplementGetAllRequest request)
        {
            var suplementi = await db.Suplement
                .Select(x => new SuplementGetAllResponseRow
                {
                    ID = x.ID,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena,
                    Gramaža = x.Gramaza,
                    Opis = x.Opis,
                    NazivDobavljaca = x.Dobavljac.Naziv,
                    NazivKategorija = x.Kategorija.Naziv
                }).ToListAsync();

            return new SuplementGetAllResponse
            {
                Suplementi = suplementi
            };

        }
    }
}
