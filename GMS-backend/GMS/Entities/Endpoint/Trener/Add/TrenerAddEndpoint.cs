using GMS.Data;
using GMS.Entities.Endpoint.Suplement.Add;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Trener.Add
{
    [Route("Trener-Add")]

    public class TrenerAddEndpoint : MyBaseEndpoint<TrenerAddRequest, TrenerAddResponse>
    {
        private readonly ApplicationDbContext db;

        public TrenerAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<TrenerAddResponse> Handle([FromBody]TrenerAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Trener
            {
                Ime=request.Ime,
                Prezime=request.Prezime,
                BrojTelefona=request.BrojTelefona,
                Slika=request.Slika
                
            };

            db.Trener.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new TrenerAddResponse
            {
                ID = novi.ID,
                Ime=novi.Ime,
                Prezime=novi.Prezime,
                BrojTelefona=novi.Prezime,
                Slika=novi.Slika
            };

        }
    }
}
