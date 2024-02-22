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
            var lastTwoFKeys = await db.AutentifikacijaToken
                .GroupBy(x => x.KorisnickiNalogId)
                .Select(group => new
                {
                    KorisnickiNalogId = group.Key,
                    LastTwoFKey = group.OrderByDescending(x => x.id).Select(x => x.TwoFKey).FirstOrDefault()
                })
                .ToListAsync(cancellationToken);

            var tfas = lastTwoFKeys.Select(x => new TfasGetAllResponseRow
            {
                ID = x.KorisnickiNalogId,
                TwoFKey = x.LastTwoFKey
            }).ToList();

            return new TfaGetAllResponse
            {
                Tfas = tfas
            };
        }
    }
}
