using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GMS.Configuration
{
    public class Trener_SeminarConfiguration : IEntityTypeConfiguration<Trener_Seminar>
    {
        public void Configure(EntityTypeBuilder<Trener_Seminar> builder)
        {
            builder.HasData(
                new Trener_Seminar
                {
                    TrenerID = 1,
                    SeminarID = 5
                },
                new Trener_Seminar
                {
                    TrenerID = 1,
                    SeminarID = 6
                },
                new Trener_Seminar
                {
                    TrenerID = 2,
                    SeminarID = 4
                },
                new Trener_Seminar
                {
                    TrenerID = 2,
                    SeminarID = 6
                });
                
        }
    }
}
