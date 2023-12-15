using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Suplement.Edit
{
    [Route("Suplement-Edit")]
    [MyAuthorization]

    public class SuplementiEditEndpoint : MyBaseEndpoint<SuplementiEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public SuplementiEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]SuplementiEditRequest request, CancellationToken cancellationToken)
        {
            Models.Suplement? suplement;
            if (request.ID == 0)
            {
                suplement = new Models.Suplement();
                db.Add(suplement);


            }
            else
            {
                suplement = db.Suplement.FirstOrDefault(s => s.ID == request.ID);
                if (suplement == null)
                    throw new Exception("pogresan ID");
            }

            suplement.Naziv = request.Naziv.RemoveTags();
            suplement.Cijena = request.Cijena;
            suplement.Gramaza = request.Gramaza;
            suplement.Opis = request.Opis.RemoveTags();
            suplement.Slika = request.Slika.RemoveTags();


            await db.SaveChangesAsync(cancellationToken);

            return suplement.ID;
            
        }
    }
}
