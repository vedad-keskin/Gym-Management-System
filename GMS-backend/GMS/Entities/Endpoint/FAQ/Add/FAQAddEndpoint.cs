using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using GMS.Helpers.Services;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.FAQ.Add
{
    [Route("FAQ-Add")]
    [MyAuthorization]

    public class FAQAddEndpoint : MyBaseEndpoint<FAQAddRequest, FAQAddResponse>
    {
        private readonly ApplicationDbContext db;
        private readonly MyAuthService auth;

        public FAQAddEndpoint(ApplicationDbContext db, MyAuthService auth)
        {
            this.db = db;
            this.auth = auth;
        }

        [HttpPost]
        public override async Task<FAQAddResponse> Handle([FromBody]FAQAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.FAQ
            {
               Pitanje=request.Pitanje,
               Odgovor=request.Odgovor
            };

            db.FAQ.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new FAQAddResponse
            {
                ID = novi.ID,
                
            };
        }
    }
}
