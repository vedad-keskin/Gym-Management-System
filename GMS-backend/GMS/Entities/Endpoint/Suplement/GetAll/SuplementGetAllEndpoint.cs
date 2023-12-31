﻿using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Suplement.GetAll
{
    [Route("Suplement-GetAll")]

    public class SuplementGetAllEndpoint : MyBaseEndpoint<SuplementGetAllRequest, SuplementGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public SuplementGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<SuplementGetAllResponse> Handle([FromQuery] SuplementGetAllRequest request, CancellationToken cancellationToken)
        {
            var suplementi = await db.Suplement
                .Select(x => new SuplementGetAllResponseRow
                {
                    ID = x.ID,
                    Naziv = x.Naziv,
                    Cijena = x.Cijena,
                    Gramaza = x.Gramaza,
                    Opis = x.Opis,
                    Slika = x.Slika,
                    NazivDobavljaca = x.Dobavljac.Naziv,
                    NazivKategorija = x.Kategorija.Naziv,
                    DobavljacID = x.DobavljacID,
                    KategorijaID = x.KategorijaID
                }).ToListAsync(cancellationToken: cancellationToken);

            return new SuplementGetAllResponse
            {
                Suplementi = suplementi
            };

        }
    }
}
