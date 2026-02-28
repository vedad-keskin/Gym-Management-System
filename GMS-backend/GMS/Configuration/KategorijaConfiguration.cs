using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GMS.Configuration
{
    public class KateogorijaConfiguration : IEntityTypeConfiguration<Kategorija>
    {
        public void Configure(EntityTypeBuilder<Kategorija> builder)
        {
            builder.HasData(
                new Kategorija
                {
                    ID = 1,
                    Naziv = "Proteini",
                },
                new Kategorija
                {
                    ID = 2,
                    Naziv = "Amino kiseline",
                },
                new Kategorija
                {
                    ID = 3,
                    Naziv = "Preworkout",
                },
                new Kategorija
                {
                    ID = 4,
                    Naziv = "Mass gaineri",
                });
                
        }
    }
}
