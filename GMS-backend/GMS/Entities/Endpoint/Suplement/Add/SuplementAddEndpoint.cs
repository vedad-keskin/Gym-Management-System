using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Suplement.Add
{
    [Route("Suplement-Add")]
    [MyAuthorization]

    public class SuplementAddEndpoint : MyBaseEndpoint<SuplementAddRequest, SuplementAddResponse>
    {
        private readonly ApplicationDbContext db;

        public SuplementAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<SuplementAddResponse> Handle([FromBody]SuplementAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Suplement
            {
                Naziv = request.Naziv,
                Cijena=request.Cijena,
                Gramaza=request.Gramaza,
                Opis=request.Opis,
                Slika=request.Slika,
                DobavljacID=request.DobavljacID,
                KategorijaID=request.KategorijaID
            };

            db.Suplement.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new SuplementAddResponse
            {
                ID = novi.ID,
                Naziv = novi.Naziv,
                Cijena=novi.Cijena,
                Gramaza=novi.Gramaza,
                Opis=novi.Opis,
                Slika=novi.Slika,
                DobavljacID=novi.DobavljacID,
                KategorijaID=novi.KategorijaID

            };
        }
    }
}
