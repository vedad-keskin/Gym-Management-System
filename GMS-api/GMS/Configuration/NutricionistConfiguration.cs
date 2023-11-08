using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GMS.Configuration
{
    public class NutricionistConfiguration : IEntityTypeConfiguration<Nutricionist>
    {
        public void Configure(EntityTypeBuilder<Nutricionist> builder)
        {
            builder.HasData(
                new Nutricionist
                {
                    ID = 1,
                    Ime = "Marijana",
                    Prezime = "Zubac",
                    BrojTelefona = "062709689"
                },
                new Nutricionist
                {
                    ID = 2,
                    Ime = "Amela",
                    Prezime = "Ivković",
                    BrojTelefona = "062709689"
                });
                
        }
    }
}
