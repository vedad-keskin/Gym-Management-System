using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;

namespace GMS.Entities.Endpoint.Recenzija.Edit
{
    [Route("Recenzija-Edit")]
    [MyAuthorization]

    public class RecenzijeEditEndpoint : MyBaseEndpoint<RecenzijeEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public RecenzijeEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]RecenzijeEditRequest request, CancellationToken cancellationToken)
        {
            Models.Recenzija? recenzija;
            if (request.ID == 0)
            {
                recenzija = new Models.Recenzija();
                db.Add(recenzija);


            }
            else
            {
                recenzija = db.Recenzija.FirstOrDefault(s => s.ID == request.ID);
                if (recenzija == null)
                    throw new Exception("pogresan ID");
            }

            recenzija.Ime = request.Ime.RemoveTags();
            recenzija.Prezime = request.Prezime.RemoveTags();
            recenzija.Zanimanje = request.Zanimanje.RemoveTags();
            recenzija.Tekst = request.Tekst.RemoveTags();
            recenzija.Slika = request.Slika?.RemoveTags();


            await db.SaveChangesAsync(cancellationToken);

            return recenzija.ID;
        }
    }
}
