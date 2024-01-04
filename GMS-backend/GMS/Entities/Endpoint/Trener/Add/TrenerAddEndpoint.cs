using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Trener.Add
{
    [Route("Trener-Add")]
    [MyAuthorization]

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
            var novi = new Entities.Models.Trener();

            novi.BrojTelefona = request.BrojTelefona.RemoveTags();
            novi.Ime = request.Ime.RemoveTags();
            novi.Prezime = request.Prezime.RemoveTags();

            if (!string.IsNullOrEmpty(request.Slika))
            {
                byte[]? slika_bajtovi = request.Slika?.ParseBase65();
            }

            // treba ovo zavrsiti 
            novi.Slika = request.Slika;


            db.Trener.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new TrenerAddResponse
            {
                ID = novi.ID,
                Ime=novi.Ime,
                Prezime=novi.Prezime,
                BrojTelefona=novi.BrojTelefona,
                Slika=novi.Slika
            };
        }
    }
}
