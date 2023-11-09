using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GMS.Configuration
{
    public class KorisnikConfiguration : IEntityTypeConfiguration<Korisnik>
    {
        public void Configure(EntityTypeBuilder<Korisnik> builder)
        {
            builder.HasData(
                new Korisnik
                {
                    ID = 1,
                    Ime = "Vedad",
                    Prezime = "Keskin",
                    Username = "vedadke",
                    Password = "bayern123",
                    BrojTelefona = "0644076290",
                    Visina = 170,
                    Tezina = 80,
                    SpolID = 1,
                    GradID = 18,
                    TeretanaID = 2,
                    Slika = "assets/1kor.png"
                },
                new Korisnik
                {
                    ID = 2,
                    Ime = "Džejla",
                    Prezime = "Palalić",
                    Username = "dzejlap",
                    Password = "fit2023",
                    BrojTelefona = "062709689",
                    Visina = 164,
                    Tezina = 57,
                    SpolID = 2,
                    GradID = 26,
                    TeretanaID = 2,
                    Slika = "assets/2kor.jpg"
                }
                ,
                new Korisnik
                {
                    ID = 3,
                    Ime = "Said",
                    Prezime = "Keskin",
                    Username = "saidke",
                    Password = "fit2023",
                    BrojTelefona = "0644065144",
                    Visina = 180,
                    Tezina = 62,
                    SpolID = 1,
                    GradID = 18,
                    TeretanaID = 2,
                    Slika = "assets/3kor.jpg"
                },
                new Korisnik
                {
                    ID = 4,
                    Ime = "Denis",
                    Prezime = "Mušić",
                    Username = "denism",
                    Password = "user",
                    BrojTelefona = "061000000",
                    Visina = 186,
                    Tezina = 79,
                    SpolID = 1,
                    GradID = 5,
                    TeretanaID = 2,
                    Slika = "assets/4kor.jpg"
                }
                ,
                new Korisnik
                {
                    ID = 5,
                    Ime = "Adil",
                    Prezime = "Joldić",
                    Username = "adilj",
                    Password = "user",
                    BrojTelefona = "062000000",
                    Visina = 184,
                    Tezina = 75,
                    SpolID = 1,
                    GradID = 7,
                    TeretanaID = 2,
                    Slika = "assets/5kor.jpg"
                });
                
        }
    }
}
