using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Kategorija.Edit
{
    [Route("Kategorija-Edit")]
    [MyAuthorization]

    public class KategorijeEditEndpoint : MyBaseEndpoint<KategorijeEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public KategorijeEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]KategorijeEditRequest request, CancellationToken cancellationToken)
        {
            Models.Kategorija? kategorija;
            if (request.ID == 0)
            {
                kategorija = new Models.Kategorija();
                db.Add(kategorija);


            }
            else
            {
                kategorija = db.Kategorija.FirstOrDefault(s => s.ID == request.ID);
                if (kategorija == null)
                    throw new Exception("pogresan ID");
            }

            kategorija.Naziv = request.Naziv.RemoveTags();


            await db.SaveChangesAsync(cancellationToken);

            return kategorija.ID;
        }
    }
}
