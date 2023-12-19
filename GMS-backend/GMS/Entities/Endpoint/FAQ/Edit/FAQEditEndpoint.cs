using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.FAQ.Edit
{
    [Route("FAQ-Edit")]
    [MyAuthorization]

    public class FAQEditEndpoint : MyBaseEndpoint<FAQEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public FAQEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]FAQEditRequest request, CancellationToken cancellationToken)
        {
            Models.FAQ? FAQ;
            if (request.ID == 0)
            {
                FAQ = new Models.FAQ();
                db.Add(FAQ);


            }
            else
            {
                FAQ = db.FAQ.FirstOrDefault(s => s.ID == request.ID);
                if (FAQ == null)
                    throw new Exception("pogresan ID");
            }

            FAQ.Pitanje = request.Pitanje.RemoveTags();
            FAQ.Odgovor = request.Odgovor.RemoveTags();


            await db.SaveChangesAsync(cancellationToken);

            return FAQ.ID;
        }
    }
}
