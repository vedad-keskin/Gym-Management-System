using FIT_Api_Example.Helper.Auth;
using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Nutricionist.Edit
{
    [Route("Nutricionist-Edit")]
    [MyAuthorization]

    public class NutricionistiEditEndpoint : MyBaseEndpoint<NutricionistiEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public NutricionistiEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]NutricionistiEditRequest request, CancellationToken cancellationToken)
        {
            Models.Nutricionist? nutricionist;
            if (request.ID == 0)
            {
                nutricionist = new Models.Nutricionist();
                db.Add(nutricionist);


            }
            else
            {
                nutricionist = db.Nutricionist.FirstOrDefault(s => s.ID == request.ID);
                if (nutricionist == null)
                    throw new Exception("pogresan ID");
            }

            nutricionist.Ime = request.Ime.RemoveTags();
            nutricionist.Prezime = request.Prezime.RemoveTags();
            nutricionist.BrojTelefona = request.BrojTelefona.RemoveTags();
            nutricionist.Slika = request.Slika.RemoveTags();

            await db.SaveChangesAsync(cancellationToken);

            return nutricionist.ID;
        }
    }
    
}
