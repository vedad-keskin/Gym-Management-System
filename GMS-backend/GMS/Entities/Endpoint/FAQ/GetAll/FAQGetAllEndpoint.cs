using GMS.Data;
using GMS.Entities.Endpoint.FAQ.GetAll;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMS.Entities.Endpoint.FAQ.GetAll
{
    [Route("FAQ-GetAll")]

    public class FAQGetAllEndpoint : MyBaseEndpoint<FAQGetAllRequest, FAQGetAllResponse>
    {
        private readonly ApplicationDbContext db;

        public FAQGetAllEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public override async Task<FAQGetAllResponse> Handle([FromQuery] FAQGetAllRequest request)
        {
            var faq = await db.FAQ
                .Select(x => new FAQGetAllResponseRow
                {
                    ID = x.ID,
                    Pitanje = x.Pitanje,
                    Odgovor = x.Odgovor


                }).ToListAsync();

            return new FAQGetAllResponse
            {
                FAQ = faq
            };
        }
    }

}
