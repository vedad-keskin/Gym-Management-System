using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Grad.Edit
{
    [Route("Grad-Edit")]
    [MyAuthorization]

    public class GradoviEditEndpoint : MyBaseEndpoint<GradoviEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public GradoviEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]GradoviEditRequest request, CancellationToken cancellationToken)
        {
            Models.Grad? grad;
            if (request.ID == 0)
            {
                grad = new Models.Grad();
                db.Add(grad);


            }
            else
            {
                grad = db.Grad.FirstOrDefault(s => s.ID == request.ID);
                if (grad == null)
                    throw new Exception("pogresan ID");
            }

            grad.Naziv = request.Naziv.RemoveTags();
           

            await db.SaveChangesAsync(cancellationToken);

            return grad.ID;
        }
    }
}
