using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Korisnik_Clanarina.Add
{
    [Route("Korisnik_Clanarina-Add")]
    //[MyAuthorization]

    public class Korisnik_ClanarinaAddEndpoint : MyBaseEndpoint<Korisnik_ClanarinaAddRequest, Korisnik_ClanarinaAddResponse>
    {
        private readonly ApplicationDbContext db;

        public Korisnik_ClanarinaAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<Korisnik_ClanarinaAddResponse> Handle([FromBody]Korisnik_ClanarinaAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Korisnik_Clanarina
            {
                ClanarinaID= request.ClanarinaID,
                KorisnikID=request.KorisnikID,
                DatumUplate=request.DatumUplate,
                DatumIsteka=request.DatumIsteka
            };

            db.Korisnik_Clanarina.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new Korisnik_ClanarinaAddResponse
            {
                ClanarinaID = novi.ClanarinaID,
                KorisnikID = novi.KorisnikID,
                DatumUplate=novi.DatumUplate,
                DatumIsteka=novi.DatumIsteka
            };
        }
    }
}
