using FIT_Api_Example.Helper.Auth;
using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Korisnik.Edit
{
    [Route("Korisnik-Edit")]
    [MyAuthorization]

    public class KorisniciEditEndpoint : MyBaseEndpoint<KorisniciEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public KorisniciEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]KorisniciEditRequest request, CancellationToken cancellationToken)
        {
            Models.Korisnik? korisnik;
            if (request.ID == 0)
            {
                korisnik = new Models.Korisnik();
                db.Add(korisnik);


            }
            else
            {
                korisnik = db.Korisnik.FirstOrDefault(s => s.ID == request.ID);
                if (korisnik == null)
                    throw new Exception("pogresan ID");
            }

            korisnik.Ime = request.Ime.RemoveTags();
            korisnik.Prezime = request.Prezime.RemoveTags();
            korisnik.Username = request.Username.RemoveTags();
            korisnik.Password = request.Password.RemoveTags();
            korisnik.Slika = request.Slika.RemoveTags();
            korisnik.BrojTelefona = request.BrojTelefona.RemoveTags();
            korisnik.Visina = request.Visina;
            korisnik.Tezina = request.Tezina;
           

            await db.SaveChangesAsync(cancellationToken);

            return korisnik.ID;
        }
    }
}
