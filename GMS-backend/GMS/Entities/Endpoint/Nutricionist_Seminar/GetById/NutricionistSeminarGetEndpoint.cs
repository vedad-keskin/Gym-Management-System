using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Nutricionist_Seminar.GetById
{
    [Route("Nutricionist-Seminar-Get")]

    public class NutricionistSeminarGetEndpoint : MyBaseEndpoint<int, NutricionistSeminarGetResponse>
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly MyAuthService _authService;

        public NutricionistSeminarGetEndpoint(ApplicationDbContext applicationDbContext, MyAuthService authService)
        {
            _applicationDbContext = applicationDbContext;
            _authService = authService;
        }

        [HttpGet("{id}")]
        public override async Task<NutricionistSeminarGetResponse> Handle(int id, CancellationToken cancellationToken)
        {
            var nutricionist = await _applicationDbContext.Nutricionist.FindAsync(id);

            if (nutricionist is null)
                throw new Exception("Nije nađen nutricionist za id = " + id);

            var result = new NutricionistSeminarGetResponse
            {
                NutricionistID = nutricionist.ID,
                Ime = nutricionist.Ime,
                Prezime = nutricionist.Prezime,
                PrisustvoSeminaru = await _applicationDbContext
                    .Nutricionist_Seminar.Include("Seminar").Include("Nutricionist")
                    .Where(x => x.NutricionistID == id)
                    .Select(x => new NutricionistSeminarGetResponsePrisustvoSeminaru
                    {
                        NutricionistID=x.NutricionistID,
                        SeminarID=x.SeminarID
                    })
                    .ToListAsync(cancellationToken)
            };



            return result;
        }
    }
}
