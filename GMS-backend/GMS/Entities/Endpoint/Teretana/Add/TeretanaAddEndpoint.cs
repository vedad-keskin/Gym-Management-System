using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Teretana.Add
{
    [Route("Teretana-Add")]
    [MyAuthorization]

    public class TeretanaAddEndpoint : MyBaseEndpoint<TeretanaAddRequest, TeretanaAddResponse>
    {
        private readonly ApplicationDbContext db;
        

        public TeretanaAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
            
        }

        [HttpPost]
        public override async Task<TeretanaAddResponse> Handle([FromBody]TeretanaAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Teretana
            {
                Naziv = request.Naziv,
                Adresa=request.Adresa,
                GradID=request.GradID
                
            };

            db.Teretana.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new TeretanaAddResponse
            {
                ID = novi.ID,
                Naziv=novi.Naziv,
                GradID=novi.GradID,
                Adresa=novi.Adresa
                
            };
        }
    }
}
