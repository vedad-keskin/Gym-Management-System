using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GMS.Configuration
{
    public class TeretanaConfiguration : IEntityTypeConfiguration<Teretana>
    {
        public void Configure(EntityTypeBuilder<Teretana> builder)
        {
            builder.HasData(
                new Teretana
                {
                    ID = 1,
                    Naziv = "ProGym Fitness Centar",
                    GradID = 22,
                    Adresa = "Patriotske lige bb"
                },
                new Teretana
                {
                    ID = 2,
                    Naziv = "Bodyline Mostar",
                    GradID = 18,
                    Adresa = "Novo naselje Zalik bb"
                },
                new Teretana
                {
                    ID = 3,
                    Naziv = "Body Control",
                    GradID = 27,
                    Adresa = "Turalibegova 25a"
                },
                new Teretana
                {
                    ID = 4,
                    Naziv = "Blue Line Fitness",
                    GradID = 1,
                    Adresa = "Veljka Mlađenovića bb"
                },
                new Teretana
                {
                    ID = 5,
                    Naziv = "ZEFIT Gym",
                    GradID = 30,
                    Adresa = "Trg Alije Izetbegovića 86"
                },
                new Teretana
                {
                    ID = 6,
                    Naziv = "Reflex Gym",
                    GradID = 2,
                    Adresa = "Sarajevska k-1"
                },
                new Teretana
                {
                    ID = 7,
                    Naziv = "No Limits Gym",
                    GradID = 13,
                    Adresa = "Željeznička 2, Konjic"
                });
                
        }
    }
}
