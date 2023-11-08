using GMS.Configuration;
using GMS.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace GMS.Data
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Korisnik_Clanarina>().HasKey(x => new { x.ClanarinaID, x.KorisnikID, x.DatumUplate });

            modelBuilder.Entity<Korisnik_Trener>().HasKey(x => new { x.KorisnikID, x.TrenerID, x.DatumTermina });

            modelBuilder.Entity<Trener_Seminar>().HasKey(x => new { x.TrenerID, x.SeminarID });

            modelBuilder.Entity<Korisnik_Nutricionist>().HasKey(x => new { x.KorisnikID, x.NutricionistID, x.DatumTermina });

            modelBuilder.Entity<Nutricionist_Seminar>().HasKey(x => new { x.NutricionistID, x.SeminarID });

            modelBuilder.Entity<Korisnik_Suplement>().HasKey(x => new { x.SuplementID, x.KorisnikID, x.DatumVrijemeNarudzbe });






            modelBuilder.ApplyConfiguration(new GradConfiguration());
            modelBuilder.ApplyConfiguration(new SpolConfiguration());
            modelBuilder.ApplyConfiguration(new ClanarinaConfiguration());
            modelBuilder.ApplyConfiguration(new AdministratorConfiguration());
            modelBuilder.ApplyConfiguration(new TeretanaConfiguration());
            modelBuilder.ApplyConfiguration(new KorisnikConfiguration());
            modelBuilder.ApplyConfiguration(new Korisnik_ClanarinaConfiguration());
            modelBuilder.ApplyConfiguration(new DobavljacConfiguration());
            modelBuilder.ApplyConfiguration(new KateogorijaConfiguration());
            modelBuilder.ApplyConfiguration(new SuplementConfiguration());
            modelBuilder.ApplyConfiguration(new RecenzijaConfiguration());
            modelBuilder.ApplyConfiguration(new TrenerConfiguration());
            modelBuilder.ApplyConfiguration(new SeminarConfiguration());
            modelBuilder.ApplyConfiguration(new NutricionistConfiguration());
            modelBuilder.ApplyConfiguration(new Nutricionst_SeminarConfiguration());
            modelBuilder.ApplyConfiguration(new Trener_SeminarConfiguration());
        }
        public DbSet<Grad> Grad { get; set; }
        public DbSet<Spol> Spol { get; set; }
        public DbSet<Teretana> Teretana { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Korisnik_Clanarina> Korisnik_Clanarina { get; set; }
        public DbSet<Clanarina> Clanarina { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<FAQ> FAQ { get; set; }
        public DbSet<Trener> Trener { get; set; }
        public DbSet<Korisnik_Trener> Korisnik_Trener { get; set; }
        public DbSet<Seminar> Seminar { get; set; }
        public DbSet<Trener_Seminar> Trener_Seminar { get; set; }
        public DbSet<Nutricionist> Nutricionist { get; set; }
        public DbSet<Korisnik_Nutricionist> Korisnik_Nutricionst { get; set; }
        public DbSet<Nutricionist_Seminar> Nutricionist_Seminar { get; set; }
        public DbSet<Suplement> Suplement { get; set; }
        public DbSet<Korisnik_Suplement> Korisnik_Suplement { get; set; }
        public DbSet<Recenzija> Recenzija { get; set; }
        public DbSet<Dobavljac> Dobavljac { get; set; }
        public DbSet<Kategorija> Kategorija { get; set; }


        public ApplicationDbContext(
            DbContextOptions options) : base(options)
        {
        }
    }
}
