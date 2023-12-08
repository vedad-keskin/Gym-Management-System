using GMS.Data;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Dobavljac.Edit
{
    [Route("Dobavljac-Edit")]

    public class DobavljaciEditEndpoint : MyBaseEndpoint<DobavljaciEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public DobavljaciEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]DobavljaciEditRequest request, CancellationToken cancellationToken)
        {
            Models.Dobavljac? dobavljac;
            if (request.ID == 0)
            {
                dobavljac = new Models.Dobavljac();
                db.Add(dobavljac);


            }
            else
            {
                dobavljac = db.Dobavljac.FirstOrDefault(s => s.ID == request.ID);
                if (dobavljac == null)
                    throw new Exception("pogresan ID");
            }

            dobavljac.Naziv = request.Naziv.RemoveTags();



            await db.SaveChangesAsync(cancellationToken);

            return dobavljac.ID;
        }
    }
}
