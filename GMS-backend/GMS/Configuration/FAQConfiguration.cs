using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GMS.Configuration
{
    public class FAQConfiguration : IEntityTypeConfiguration<FAQ>
    {
        public void Configure(EntityTypeBuilder<FAQ> builder)
        {
            builder.HasData(
                new FAQ
                {
                    ID = 1,
                    Pitanje = "Koja je cijena članarina u vašoj teretani?",
                    Odgovor = "Cijene mjesečnih članarina variraju ovisno o paketu koji odaberete. Imamo različite opcije  prilagođene različitim potrebama i budžetima. Detaljne informacije o cijenama možete pronaći na homepage pod sekcijom 'cjenovnik članarina'."
                },
                new FAQ
                {
                    ID = 2,
                    Pitanje = "Da li u sklopu teretane imate personalne trenere?",
                    Odgovor = "Da, imamo stručne trenere koji vam mogu pomoći u postizanju vaših fitness ciljeva. Oni će raditi s vama kako bi razvili personalizirani plan vježbanja. Pored njih, imamo i naš tim nutricionista."
                },
                new FAQ
                {
                    ID = 3,
                    Pitanje = "Kako da postanem član vaše teretane?",
                    Odgovor = "Vrlo jednostavno! Posjetite našu recepciju, odaberite željeni paket i dobit ćete svoju člansku karticu!"
                },
                new FAQ
                {
                    ID = 4,
                    Pitanje = "Gdje se nalazi vaša teretana?",
                    Odgovor = "Tačnu lokaciju naše teretane možete pogledati na homepage pod rubrikom 'kako do nas?'."
                },
                new FAQ
                {
                    ID = 5,
                    Pitanje = "Kako izvršiti kupovinu suplemenata?",
                    Odgovor = "Kupovinu suplemenata izvršavate putem sekcije suplementi, pomoću koje rezervišete vas proizvod koji nakon toga trebate preuzeti u našoj poslovnici te platiti po uzeću."
                });
                
        }
    }
}
