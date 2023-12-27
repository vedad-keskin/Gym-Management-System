using GMS.Data;
using GMS.Helpers;
using GMS.Helpers.Auth;
using Microsoft.AspNetCore.Mvc;
using SkiaSharp;

namespace GMS.Entities.Endpoint.Trener.Add
{
    [Route("Trener-Add")]
    [MyAuthorization]

    public class TrenerAddEndpoint : MyBaseEndpoint<TrenerAddRequest, TrenerAddResponse>
    {
        private readonly ApplicationDbContext db;

        public TrenerAddEndpoint(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public override async Task<TrenerAddResponse> Handle([FromBody]TrenerAddRequest request, CancellationToken cancellationToken)
        {
            var novi = new Entities.Models.Trener();

            novi.BrojTelefona = request.BrojTelefona.RemoveTags();
            novi.Ime = request.Ime.RemoveTags();
            novi.Prezime = request.Prezime.RemoveTags();

            if (!string.IsNullOrEmpty(request.Slika))
            {
                byte[]? slika_bajtovi = request.Slika?.ParseBase65();

                byte[]? slika_bajtovi_resized_velika = resize(slika_bajtovi, 200);
                byte[]? slika_bajtovi_resized_mala = resize(slika_bajtovi, 50);

            }

            // treba ovo zavrsiti 
            novi.Slika = request.Slika;


            db.Trener.Add(novi);
            await db.SaveChangesAsync(cancellationToken: cancellationToken);

            return new TrenerAddResponse
            {
                ID = novi.ID,
                Ime=novi.Ime,
                Prezime=novi.Prezime,
                BrojTelefona=novi.BrojTelefona,
                Slika=novi.Slika
            };
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
