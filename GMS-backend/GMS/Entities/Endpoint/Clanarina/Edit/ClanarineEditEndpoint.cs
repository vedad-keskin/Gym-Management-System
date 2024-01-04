using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.Clanarina.Edit
{

    [Route("Clanarina-Edit")]
    [MyAuthorization]

    public class ClanarineEditEndpoint : MyBaseEndpoint<ClanarineEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public ClanarineEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody] ClanarineEditRequest request, CancellationToken cancellationToken)
        {
            Models.Clanarina? clanarina;
            if (request.ID == 0)
            {
                clanarina = new Models.Clanarina();
                db.Add(clanarina);


            }
            else
            {
                clanarina = db.Clanarina.FirstOrDefault(s => s.ID == request.ID);
                if (clanarina == null)
                    throw new Exception("pogresan ID");
            }

            clanarina.Naziv = request.Naziv.RemoveTags();
            clanarina.Cijena = request.Cijena;
            clanarina.Opis = request.Opis.RemoveTags();



            await db.SaveChangesAsync(cancellationToken);

            return clanarina.ID;
        }
    }
}

