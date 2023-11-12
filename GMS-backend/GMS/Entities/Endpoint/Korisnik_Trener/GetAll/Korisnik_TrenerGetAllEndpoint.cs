using GMS.Data;
<<<<<<< HEAD
=======
using GMS.Entities.Endpoint.Korisnik_Nutricionist.GetAll;
>>>>>>> 77a924fbcf54ddf95a8e203f21e93249be549661
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Korisnik_Trener.GetAll
{
<<<<<<< HEAD
=======

>>>>>>> 77a924fbcf54ddf95a8e203f21e93249be549661
    [Route("Korisnik_Trener-GetAll")]

    public class Korisnik_TrenerGetAllEndpoint : MyBaseEndpoint<Korisnik_TrenerGetAllRequest, Korisnik_TrenerGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public Korisnik_TrenerGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
<<<<<<< HEAD
        public override async Task<Korisnik_TrenerGetAllResponse> Handle([FromQuery]Korisnik_TrenerGetAllRequest request)
        {
            var korisniktrener = await db.Korisnik_Trener
                .Select(x => new KorisnikTrenerGetAllResponseRow
                {
                    KorisnikID=x.KorisnikID,
                    TrenerID=x.TrenerID,
                    OdrzanoSati=x.OdrzanoSati,
                   
=======
        public override async Task<Korisnik_TrenerGetAllResponse> Handle([FromQuery] Korisnik_TrenerGetAllRequest request)
        {
            var korisnici_treneri = await db.Korisnik_Trener
                .Select(x => new KorisnikTrenerGetAllResponseRow
                {
                    KorisnikID = x.KorisnikID,
                    TrenerID = x.TrenerID,
                    DatumiVrijemeOdrzavanja = x.DatumTermina,
                    OdrzanoSati = x.OdrzanoSati

>>>>>>> 77a924fbcf54ddf95a8e203f21e93249be549661
                }).ToListAsync();

            return new Korisnik_TrenerGetAllResponse
            {
<<<<<<< HEAD
                KorisnikTrener = korisniktrener
=======
                KorisnikTreneri = korisnici_treneri
>>>>>>> 77a924fbcf54ddf95a8e203f21e93249be549661
            };
        }
    }
}
