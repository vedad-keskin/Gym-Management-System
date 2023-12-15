using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Recenzija.Add
{
    [Route("Recenzija-Add")]
    [MyAuthorization]

    public class RecenzijaAddEndpoint : MyBaseEndpoint<RecenzijaAddRequest, RecenzijaAddResponse>
    {
        private readonly ApplicationDbContext db;
        

        public RecenzijaAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<RecenzijaAddResponse> Handle([FromBody]RecenzijaAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Recenzija
            {
                Ime=request.Ime,
                Prezime=request.Prezime,
                Slika=request.Slika,
                Tekst=request.Tekst,
                Zanimanje=request.Zanimanje
            };

            db.Recenzija.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new RecenzijaAddResponse
            {
                ID = novi.ID,
                Ime=novi.Ime,
                Prezime=novi.Prezime
               
            };
        }
    }
}
