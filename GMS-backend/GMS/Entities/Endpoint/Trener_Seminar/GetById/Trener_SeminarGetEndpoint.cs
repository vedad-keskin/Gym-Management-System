using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Trener_Seminar.GetById
{
    [Route("Trener-Seminar-Get")]

    public class Trener_SeminarGetEndpoint : MyBaseEndpoint<int, Trener_SeminarGetResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _authService;

        public Trener_SeminarGetEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }

        [HttpGet("{id}")]
        public override async Task<Trener_SeminarGetResponse> Handle(int id, CancellationToken cancellationToken)
        {
            var trener = await _applicationDbContext.Trener.FindAsync(id);

            if (trener is null)
                throw new Exception("Nije nađen trener za id = " + id);

            var result = new Trener_SeminarGetResponse
            {
                TrenerID=trener.ID,
                Ime = trener.Ime,
                Prezime = trener.Prezime,
                OdrzanSeminar = await _applicationDbContext
                    .Trener_Seminar.Include("Seminar").Include("Trener")
                    .Where(x => x.TrenerID == id)
                    .Select(x => new Trener_SeminarGetResponseOdrzanSeminar
                    {
                        SeminarID=x.SeminarID,
                        TrenerID=x.TrenerID

                    })
                    .ToListAsync(cancellationToken)
            };
            return result;
        }
    }
}
