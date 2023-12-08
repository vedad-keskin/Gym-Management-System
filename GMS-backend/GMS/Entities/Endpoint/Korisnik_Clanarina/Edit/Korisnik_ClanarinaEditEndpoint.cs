using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Korisnik_Clanarina.Edit
{
    [Route("Korisnik_Clanarina-Edit")]

    public class Korisnik_ClanarinaEditEndpoint : MyBaseEndpoint<Korisnik_ClanarinaEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public Korisnik_ClanarinaEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]Korisnik_ClanarinaEditRequest request, CancellationToken cancellationToken)
        {
            Models.Korisnik_Clanarina? korisnik_clanarina;
            if (request.KorisnikID == 0)
            {
                korisnik_clanarina = new Models.Korisnik_Clanarina();
                db.Add(korisnik_clanarina);


            }
            else
            {
                korisnik_clanarina = db.Korisnik_Clanarina.FirstOrDefault(s => s.KorisnikID == request.KorisnikID);
                if (korisnik_clanarina == null)
                    throw new Exception("pogresan ID");
            }

            korisnik_clanarina.DatumUplate = request.DatumUplate;
            korisnik_clanarina.DatumIsteka = request.DatumIsteka;
          

            await db.SaveChangesAsync(cancellationToken);

            return korisnik_clanarina.KorisnikID;
        }
    }
}
