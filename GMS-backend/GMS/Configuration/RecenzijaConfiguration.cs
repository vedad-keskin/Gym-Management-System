using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GMS.Configuration
{
    public class RecenzijaConfiguration : IEntityTypeConfiguration<Recenzija>
    {
        public void Configure(EntityTypeBuilder<Recenzija> builder)
        {
            builder.HasData(
                new Recenzija
                {
                    ID = 1,
                    Ime = "Jusuf",
                    Prezime = "Nurkić",
                    Zanimanje = "Košarkaš",
                    Tekst = "Toplo preporučujem svima koji traže vrhunsku dvoranu za fitness. Osoblje je ljubazno i obrazovano, oprema i tereni su u izvrsnom stanju, a atmosfera jako motivirajuća. To je mjesto gdje možete postići svoje fitness ciljeve i pritom se osjećati sjajno. Pridruživanje ovoj teretani bila je jedna od najboljih odluka koje sam donio za svoje zdravlje i dobrobit.",
                    Slika = "assets/1rec.jpg"

                },
                new Recenzija
                {
                    ID = 2,
                    Ime = "Miralem",
                    Prezime = "Pjanić",
                    Zanimanje = "Fudbaler",
                    Tekst = "Ako ste u potrazi za izvrsnom teretanom, ne tražite dalje. Dio sam ove porodice više od dvije godine i jako sam zadovoljan. Treneri su izvrsni, raznovrsnost opreme je impresivna, a sveukupno okruženje jako gostoljubivo. Vidio sam stvarne rezultate i osjećam se energičnije i sigurnije. Pridruživanje ovoj teretani bio je fantastičan izbor i ne mogu ga dovoljno preporučiti!",
                    Slika = "assets/2rec.jpg"

                },
                new Recenzija
                {
                    ID = 3,
                    Ime = "Luka",
                    Prezime = "Modrić",
                    Zanimanje = "Fudbaler",
                    Tekst = "Svim srcem podržavam rad ovog postrojenja kao ultimativno odredište za trening. Od najsavremenije opreme do ljubaznog osoblja koje vam pruža podršku, ova teretana ima sve što vam je potrebno za postizanje vaših fitness ciljeva. Pozitivna i motivirajuća atmosfera tjera me da se vraćam i značajno sam napredovao u svom zdravlju i kondiciji otkako sam se pridružio. Nemojte se ustručavati postati dio ove fantastične zajednice – nećete požaliti!",
                    Slika = "assets/3rec.jpg"

                },
                new Recenzija
                {
                    ID = 4,
                    Ime = "Luka",
                    Prezime = "Dončić",
                    Zanimanje = "Košarkaš",
                    Tekst = "Za uistinu izvanredno fitness iskustvo, ne mogu dovoljno preporučiti ovo mjesto. Ova teretana ima sve: dobro održavane sprave, stručne trenere i fantastičnu atmosferu. Vidio sam izvanredna poboljšanja u svojoj snazi i općem zdravlju otkako sam postao član. Ako tražite teretanu koja nadahnjuje i podržava vaše putovanje u fitness, onda je ovo pravo mjesto za vas. Pridruživanje je bila jedna od najboljih odluka koje sam donio za svoje zdravlje.",
                    Slika = "assets/4rec.jpg"

                });

        }
    }
}
