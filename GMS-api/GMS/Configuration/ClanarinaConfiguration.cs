using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GMS.Configuration
{
    public class ClanarinaConfiguration : IEntityTypeConfiguration<Clanarina>
    {
        public void Configure(EntityTypeBuilder<Clanarina> builder)
        {
            builder.HasData(
                new Clanarina
                {
                    ID = 1,
                    Naziv = "Basic",
                    Cijena = 50
                },
                new Clanarina
                {
                    ID = 2,
                    Naziv = "Studentska",
                    Cijena = 40
                },
                new Clanarina
                {
                    ID = 3,
                    Naziv = "Parovi",
                    Cijena = 30
                },
                new Clanarina
                {
                    ID = 4,
                    Naziv = "Djeca",
                    Cijena = 25
                },
                new Clanarina
                {
                    ID = 5,
                    Naziv = "Penzioneri",
                    Cijena = 25
                });
                
        }
    }
}
