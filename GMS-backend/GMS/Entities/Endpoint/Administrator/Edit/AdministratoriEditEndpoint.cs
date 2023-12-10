using GMS.Data;
using GMS.Entities.Endpoint.Administrator.Add;
using GMS.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Administrator.Edit
{
    [Route("Administrator-Edit")]

    public class AdministratoriEditEndpoint : MyBaseEndpoint<AdministratorAddRequest, int>
    {
        private readonly ApplicationDbContext db;

        public AdministratoriEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]AdministratorAddRequest request, CancellationToken cancellationToken)
        {
            Models.Administrator? administrator;
            if (request.ID == 0)
            {
                administrator = new Models.Administrator();
                db.Add(administrator);


            }
            else
            {
                administrator = db.Administrator.FirstOrDefault(s => s.ID == request.ID);
                if (administrator == null)
                    throw new Exception("pogresan ID");
            }

            administrator.Ime = request.Ime.RemoveTags();
            administrator.Prezime = request.Prezime.RemoveTags();
            administrator.Username = request.Username.RemoveTags();
            administrator.Password = request.Password.RemoveTags();


            await db.SaveChangesAsync(cancellationToken);

            return administrator.ID;
        }
    }
}
