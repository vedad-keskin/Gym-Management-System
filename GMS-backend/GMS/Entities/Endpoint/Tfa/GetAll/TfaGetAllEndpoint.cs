using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Tfa.GetAll
{
    [Route("Tfa-GetAll")]

    public class TfaGetAllEndpoint : MyBaseEndpoint<TfasGetAllRequest, TfaGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public TfaGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<TfaGetAllResponse> Handle([FromQuery] TfasGetAllRequest request, CancellationToken cancellationToken)
        {
            var tfas = await db.AutentifikacijaToken
                .Select(x => new TfasGetAllResponseRow
                {
                    ID = x.KorisnickiNalogId,
                    TwoFKey = x.TwoFKey
                }).ToListAsync(cancellationToken: cancellationToken);

            return new TfaGetAllResponse
            {
                Tfas = tfas
            };
        }
    }
}
