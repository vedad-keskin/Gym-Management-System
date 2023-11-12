﻿using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Korisnik_Trener.GetAll
{
    [Route("Korisnik_Trener-GetAll")]

    public class Korisnik_TrenerGetAllEndpoint : MyBaseEndpoint<Korisnik_TrenerGetAllRequest, Korisnik_TrenerGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public Korisnik_TrenerGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<Korisnik_TrenerGetAllResponse> Handle([FromQuery]Korisnik_TrenerGetAllRequest request)
        {
            var korisniktrener = await db.Korisnik_Trener
                .Select(x => new KorisnikTrenerGetAllResponseRow
                {
                    KorisnikID=x.KorisnikID,
                    TrenerID=x.TrenerID,
                    OdrzanoSati=x.OdrzanoSati,
                   
                }).ToListAsync();

            return new Korisnik_TrenerGetAllResponse
            {
                KorisnikTrener = korisniktrener
            };
        }
    }
}