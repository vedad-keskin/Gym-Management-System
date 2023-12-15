using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GMS.Configuration
{
    public class Korisnik_SuplementConfiguration : IEntityTypeConfiguration<Korisnik_Suplement>
    {
        public void Configure(EntityTypeBuilder<Korisnik_Suplement> builder)
        {
            builder.HasData(
                new Korisnik_Suplement
                {
                    KorisnikID = 3,
                    SuplementID = 2,
                    DatumVrijemeNarudzbe = new DateTime(2023, 09, 01, 9, 15, 0),
                    Kolicina = 3,
                    Isporuceno = false

                },
                new Korisnik_Suplement
                {
                    KorisnikID = 3,
                    SuplementID = 5,
                    DatumVrijemeNarudzbe = new DateTime(2023, 08, 02, 9, 15, 0),
                    Kolicina = 4,
                    Isporuceno = false
                },
                new Korisnik_Suplement
                {
                    KorisnikID = 3,
                    SuplementID = 4,
                    DatumVrijemeNarudzbe = new DateTime(2023, 04, 09, 9, 15, 0),
                    Kolicina = 2,
                    Isporuceno = false
                }
            );
        }
    }
}
