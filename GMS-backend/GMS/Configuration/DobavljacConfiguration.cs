using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GMS.Configuration
{
    public class DobavljacConfiguration : IEntityTypeConfiguration<Dobavljac>
    {
        public void Configure(EntityTypeBuilder<Dobavljac> builder)
        {
            builder.HasData(
                new Dobavljac
                {
                    ID = 1,
                    Naziv = "MUSCLE FREAK",
                },
                new Dobavljac
                {
                    ID = 2,
                    Naziv = "MUSCLETECH",
                },
                new Dobavljac
                {
                    ID = 3,
                    Naziv = "OPTIMUM NUTRITION",
                },
                new Dobavljac
                {
                    ID = 4,
                    Naziv = "SELF OMNINUTRITION",
                },
                new Dobavljac
                {
                    ID = 5,
                    Naziv = "CW-CHEMICAL WARFARE",
                },
                new Dobavljac
                {
                    ID = 6,
                    Naziv = "BSN",
                },
                new Dobavljac
                {
                    ID = 7,
                    Naziv = "CELLUCOR",
                },
                new Dobavljac
                {
                    ID = 8,
                    Naziv = "EVOLITE",
                },
                new Dobavljac
                {
                    ID = 9,
                    Naziv = "SUPERIOR",
                });
                
        }
    }
}
