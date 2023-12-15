using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Teretana.Edit
{
    [Route("Teretana-Edit")]

    public class TeretaneEditEndpoint : MyBaseEndpoint<TeretaneEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public TeretaneEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]TeretaneEditRequest request, CancellationToken cancellationToken)
        {
            Models.Teretana? teretana;
            if (request.ID == 0)
            {
                teretana = new Models.Teretana();
                db.Add(teretana);


            }
            else
            {
                teretana = db.Teretana.FirstOrDefault(s => s.ID == request.ID);
                if (teretana == null)
                    throw new Exception("pogresan ID");
            }

            teretana.Naziv = request.Naziv.RemoveTags();
            teretana.Adresa = request.Adresa.RemoveTags();
            teretana.GradID = request.GradID;


            await db.SaveChangesAsync(cancellationToken);

            return teretana.ID;
        }
    }
}
