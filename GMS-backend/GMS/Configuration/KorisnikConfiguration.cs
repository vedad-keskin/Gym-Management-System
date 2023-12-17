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
                    ID = 3,
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
                    Slika = "assets/1kor.png",
                    is2FActive = false
                },
                new Korisnik
                {
                    ID = 4,
                    Ime = "Džejla",
                    Prezime = "Palalić",
                    Username = "dzejlap",
                    Password = "dzejla123",
                    BrojTelefona = "062709689",
                    Visina = 165,
                    Tezina = 58,
                    SpolID = 2,
                    GradID = 33,
                    TeretanaID = 2,
                    Slika = "assets/2kor.jpg",
                    is2FActive = false
                }
                ,
                new Korisnik
                {
                    ID = 5,
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
                    Slika = "assets/3kor.jpg",
                    is2FActive = false
                },
                new Korisnik
                {
                    ID = 6,
                    Ime = "Denis",
                    Prezime = "Mušić",
                    Username = "denism",
                    Password = "fit2023",
                    BrojTelefona = "061000000",
                    Visina = 186,
                    Tezina = 79,
                    SpolID = 1,
                    GradID = 18,
                    TeretanaID = 2,
                    Slika = "assets/4kor.jpg",
                    is2FActive = false
                }
                ,
                new Korisnik
                {
                    ID = 7,
                    Ime = "Adil",
                    Prezime = "Joldić",
                    Username = "adilj",
                    Password = "fit2023",
                    BrojTelefona = "062000000",
                    Visina = 189,
                    Tezina = 75,
                    SpolID = 1,
                    GradID = 34,
                    TeretanaID = 2,
                    Slika = "assets/5kor.jpg",
                    is2FActive = false
                });

        }
    }
}
