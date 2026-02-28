using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Trener.Edit
{
    [Route("Trener-Edit")]
    [MyAuthorization]

    public class TreneriEditEndpoint : MyBaseEndpoint<TreneriEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public TreneriEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]TreneriEditRequest request, CancellationToken cancellationToken)
        {
            Models.Trener? trener;
            if (request.ID == 0)
            {
                trener = new Models.Trener();
                db.Add(trener);


            }
            else
            {
                trener = db.Trener.FirstOrDefault(s => s.ID == request.ID);
                if (trener == null)
                    throw new Exception("pogresan ID");
            }

            trener.Ime = request.Ime.RemoveTags();
            trener.Prezime = request.Prezime.RemoveTags();
            trener.BrojTelefona = request.BrojTelefona.RemoveTags();
            trener.Slika = request.Slika?.RemoveTags();
 

            await db.SaveChangesAsync(cancellationToken);

            return trener.ID;
        }
    }
}
