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
                    Ime = "Edin",
                    Prezime = "Džeko",
                    Zanimanje = "Fudbaler",
                    Tekst = "Toplo preporučujem svima koji traže vrhunsku dvoranu za fitness. Osoblje je ljubazno i obrazovano, oprema je u izvrsnom stanju, a atmosfera jako motivirajuća. To je mjesto gdje možete postići svoje fitness ciljeve i pritom se osjećati sjajno. Pridruživanje ovoj teretani bila je jedna od najboljih odluka koje sam donio za svoje zdravlje i dobrobit."

                },
                new Recenzija
                {
                    ID = 2,
                    Ime = "Jusuf",
                    Prezime = "Nurkić",
                    Zanimanje = "Košarkaš",
                    Tekst = "Ako ste u potrazi za izvrsnom teretanom, ne tražite dalje. Član sam već dvije godine i bilo je to nevjerojatno putovanje u svijet fitnesa. Treneri su izvrsni, raznolikost opreme je impresivna, a sveukupno okruženje tako gostoljubivo. Vidio sam stvarne rezultate i osjećam se energičnije i sigurnije. Pridruživanje ovoj teretani bio je fantastičan izbor i ne mogu ga dovoljno preporučiti!"

                },
                new Recenzija
                {
                    ID = 3,
                    Ime = "Lana",
                    Prezime = "Pudar",
                    Zanimanje = "Plivačica",
                    Tekst = "Svim srcem podržavam rad ovog postrojenja kao ultimativno odredište za trening. Od najsavremenije opreme do ljubaznog osoblja koje vam pruža podršku, ova teretana ima sve što vam je potrebno za postizanje vaših fitness ciljeva. Pozitivna i motivirajuća atmosfera tjera me da se vraćam i značajno sam napredovala u svom zdravlju i kondiciji otkako sam se pridružila. Nemojte se ustručavati postati dio ove fantastične zajednice – nećete požaliti!"

                },
                new Recenzija
                {
                    ID = 4,
                    Ime = "Amel",
                    Prezime = "Tuka",
                    Zanimanje = "Atletičar",
                    Tekst = "Za uistinu izvanredno fitness iskustvo, ne mogu dovoljno preporučiti ovo mjesto. Ova teretana ima sve: dobro održavane sprave, stručne trenere i fantastičnu atmosferu. Vidio sam izvanredna poboljšanja u svojoj snazi i općem zdravlju otkako sam postao član. Ako tražite teretanu koja nadahnjuje i podržava vaše putovanje u fitness, onda je ovo pravo mjesto za vas. Pridruživanje je bila jedna od najboljih odluka koje sam donio za svoje zdravlje."

                });
                
        }
    }
}
