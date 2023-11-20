using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GMS.Configuration
{
    public class AdministratorConfiguration : IEntityTypeConfiguration<Administrator>
    {
        public void Configure(EntityTypeBuilder<Administrator> builder)
        {
            builder.HasData(
                new Administrator
                {
                    ID = 1,
                    Ime = "Vedad",
                    Prezime = "Keskin",
                    Username = "admin",
                    Password = "admin"
                },
                new Administrator
                {
                    ID = 2,
                    Ime = "Džejla",
                    Prezime = "Palalić",
                    Username = "host",
                    Password = "host"
                });

        }
    }
}
