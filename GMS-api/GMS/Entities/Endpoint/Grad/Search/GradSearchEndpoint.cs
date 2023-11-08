using GMS.Controllers.Drzava.Add;
using GMS.Data;
using GMS.Endpoint.Drzava.Search;
using GMS.Entities.Models;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Controllers
{
    [Route("Grad-Search")]
    public class GradSearchEndpoint : MyBaseEndpoint<GradSearchRequest, GradSearchResponse>
    {
    private readonly ApplicationDbContext db;

    public GradSearchEndpoint(ApplicationDbContext db)
    {
        this.db = db;
    }

    [HttpGet]
        public override async Task<GradSearchResponse> Handle([FromQuery] GradSearchRequest request)
        {
            var gradovi = await db.Grad.Where(x=> request.Naziv == null 
            || x.Naziv.ToLower().StartsWith(request.Naziv.ToLower())).Select(x=> new GradSearchResponseDodatak
                {
                  ID = x.ID,
                  Naziv = x.Naziv
                }).ToListAsync();

            return new GradSearchResponse
            {
                Gradovi = gradovi
            };
        }

    }
}
