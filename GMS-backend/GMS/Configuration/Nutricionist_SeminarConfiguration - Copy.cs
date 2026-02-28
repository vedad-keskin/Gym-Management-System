using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GMS.Configuration
{
    public class Nutricionst_SeminarConfiguration : IEntityTypeConfiguration<Nutricionist_Seminar>
    {
        public void Configure(EntityTypeBuilder<Nutricionist_Seminar> builder)
        {
            builder.HasData(
                new Nutricionist_Seminar
                {
                    NutricionistID = 1,
                    SeminarID = 1
                },
                new Nutricionist_Seminar
                {
                    NutricionistID = 1,
                    SeminarID = 2
                },
                new Nutricionist_Seminar
                {
                    NutricionistID = 2,
                    SeminarID = 2
                },
                new Nutricionist_Seminar
                {
                    NutricionistID = 2,
                    SeminarID = 3
                });
                
        }
    }
}
