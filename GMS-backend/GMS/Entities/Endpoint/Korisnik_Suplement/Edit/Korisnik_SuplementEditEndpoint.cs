using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Korisnik_Suplement.Edit
{
    [Route("Korisnik_Suplement-Edit")]
    [MyAuthorization]


    public class Korisnik_SuplementEditEndpoint : MyBaseEndpoint<Korisnik_SuplementEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public Korisnik_SuplementEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]Korisnik_SuplementEditRequest request, CancellationToken cancellationToken)
        {
            Models.Korisnik_Suplement? korisnik_suplement;
            if (request.KorisnikID == 0)
            {
                korisnik_suplement = new Models.Korisnik_Suplement();
                db.Add(korisnik_suplement);


            }
            else
            {
                korisnik_suplement = db.Korisnik_Suplement.FirstOrDefault(s => s.KorisnikID == request.KorisnikID);
                if (korisnik_suplement == null)
                    throw new Exception("pogresan ID");
            }

            korisnik_suplement.DatumVrijemeNarudzbe = request.DatumVrijemeNarudzbe;
            korisnik_suplement.Isporuceno = request.Isporuceno;
            korisnik_suplement.Kolicina = request.Kolicina;
           
            


            await db.SaveChangesAsync(cancellationToken);

            return korisnik_suplement.KorisnikID;
        }
    }
}
