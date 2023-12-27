using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;
using SkiaSharp;

namespace GMS.Entities.Endpoint.Trener.Edit
{
    [Route("Trener-Edit")]
    [MyAuthorization]

    public class TreneriEditEndpoint : MyBaseEndpoint<TreneriEditRequest, int>
    {
        private readonly ApplicationDbContext db;

        public TreneriEditEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<int> Handle([FromBody]TreneriEditRequest request, CancellationToken cancellationToken)
        {
            Models.Trener? trener;
            if (request.ID == 0)
            {
                trener = new Models.Trener();
                db.Add(trener);


            }
            else
            {
                trener = db.Trener.FirstOrDefault(s => s.ID == request.ID);
                if (trener == null)
                    throw new Exception("pogresan ID");
            }

            trener.Ime = request.Ime.RemoveTags();
            trener.Prezime = request.Prezime.RemoveTags();
            trener.BrojTelefona = request.BrojTelefona.RemoveTags();


            if (!string.IsNullOrEmpty(request.Slika))
            {
                byte[]? slika_bajtovi = request.Slika?.ParseBase65();

                byte[]? slika_bajtovi_resized_velika = resize(slika_bajtovi, 200);
                byte[]? slika_bajtovi_resized_mala = resize(slika_bajtovi, 50);

            }

            trener.Slika = request.Slika;



            await db.SaveChangesAsync(cancellationToken);

            return trener.ID;
        }

        public static byte[]? resize(byte[] slikaBajtovi, int size, int quality = 75)
        {
            using var input = new MemoryStream(slikaBajtovi);
            using var inputStream = new SKManagedStream(input);
            using var original = SKBitmap.Decode(inputStream);
            int width, height;
            if (original.Width > original.Height)
            {
                width = size;
                height = original.Height * size / original.Width;
            }
            else
            {
                width = original.Width * size / original.Height;
                height = size;
            }

            using var resized = original
                .Resize(new SKImageInfo(width, height), SKBitmapResizeMethod.Lanczos3);
            if (resized == null) return null;

            using var image = SKImage.FromBitmap(resized);
            return image.Encode(SKEncodedImageFormat.Jpeg, quality)
                .ToArray();
        }
    }
}
