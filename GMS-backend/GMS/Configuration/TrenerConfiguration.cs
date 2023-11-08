using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GMS.Configuration
{
    public class TrenerConfiguration : IEntityTypeConfiguration<Trener>
    {
        public void Configure(EntityTypeBuilder<Trener> builder)
        {
            builder.HasData(
                new Trener
                {
                    ID = 1,
                    Ime = "Kadir",
                    Prezime = "Keskin",
                    BrojTelefona = "0644076290"
                },
                new Trener
                {
                    ID = 2,
                    Ime = "Azur",
                    Prezime = "Kahriman",
                    BrojTelefona = "0644076290"
                });
                
        }
    }
}
