using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMS.Migrations
{
    public partial class dbGMSdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrator",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrator", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Clanarina",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<float>(type: "real", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clanarina", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dobavljac",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dobavljac", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FAQ",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pitanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Odgovor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQ", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Grad",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grad", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Kategorija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Nutricionist",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutricionist", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Recenzija",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zanimanje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tekst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzija", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Seminar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tema = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Predavac = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seminar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Spol",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spol", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Trener",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trener", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teretana",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teretana", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teretana_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Suplement",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cijena = table.Column<float>(type: "real", nullable: false),
                    Gramaza = table.Column<float>(type: "real", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DobavljacID = table.Column<int>(type: "int", nullable: false),
                    KategorijaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplement", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Suplement_Dobavljac_DobavljacID",
                        column: x => x.DobavljacID,
                        principalTable: "Dobavljac",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Suplement_Kategorija_KategorijaID",
                        column: x => x.KategorijaID,
                        principalTable: "Kategorija",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Nutricionist_Seminar",
                columns: table => new
                {
                    NutricionistID = table.Column<int>(type: "int", nullable: false),
                    SeminarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutricionist_Seminar", x => new { x.NutricionistID, x.SeminarID });
                    table.ForeignKey(
                        name: "FK_Nutricionist_Seminar_Nutricionist_NutricionistID",
                        column: x => x.NutricionistID,
                        principalTable: "Nutricionist",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Nutricionist_Seminar_Seminar_SeminarID",
                        column: x => x.SeminarID,
                        principalTable: "Seminar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Trener_Seminar",
                columns: table => new
                {
                    TrenerID = table.Column<int>(type: "int", nullable: false),
                    SeminarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trener_Seminar", x => new { x.TrenerID, x.SeminarID });
                    table.ForeignKey(
                        name: "FK_Trener_Seminar_Seminar_SeminarID",
                        column: x => x.SeminarID,
                        principalTable: "Seminar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Trener_Seminar_Trener_TrenerID",
                        column: x => x.TrenerID,
                        principalTable: "Trener",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slika = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrojTelefona = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visina = table.Column<float>(type: "real", nullable: false),
                    Tezina = table.Column<float>(type: "real", nullable: false),
                    GradID = table.Column<int>(type: "int", nullable: false),
                    SpolID = table.Column<int>(type: "int", nullable: false),
                    TeretanaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Korisnik_Grad_GradID",
                        column: x => x.GradID,
                        principalTable: "Grad",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Korisnik_Spol_SpolID",
                        column: x => x.SpolID,
                        principalTable: "Spol",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Korisnik_Teretana_TeretanaID",
                        column: x => x.TeretanaID,
                        principalTable: "Teretana",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik_Clanarina",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    ClanarinaID = table.Column<int>(type: "int", nullable: false),
                    DatumUplate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumIsteka = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik_Clanarina", x => new { x.ClanarinaID, x.KorisnikID, x.DatumUplate });
                    table.ForeignKey(
                        name: "FK_Korisnik_Clanarina_Clanarina_ClanarinaID",
                        column: x => x.ClanarinaID,
                        principalTable: "Clanarina",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Korisnik_Clanarina_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik_Nutricionst",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    NutricionistID = table.Column<int>(type: "int", nullable: false),
                    DatumTermina = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik_Nutricionst", x => new { x.KorisnikID, x.NutricionistID, x.DatumTermina });
                    table.ForeignKey(
                        name: "FK_Korisnik_Nutricionst_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Korisnik_Nutricionst_Nutricionist_NutricionistID",
                        column: x => x.NutricionistID,
                        principalTable: "Nutricionist",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik_Suplement",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    SuplementID = table.Column<int>(type: "int", nullable: false),
                    DatumVrijemeNarudzbe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik_Suplement", x => new { x.SuplementID, x.KorisnikID, x.DatumVrijemeNarudzbe });
                    table.ForeignKey(
                        name: "FK_Korisnik_Suplement_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Korisnik_Suplement_Suplement_SuplementID",
                        column: x => x.SuplementID,
                        principalTable: "Suplement",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik_Trener",
                columns: table => new
                {
                    KorisnikID = table.Column<int>(type: "int", nullable: false),
                    TrenerID = table.Column<int>(type: "int", nullable: false),
                    DatumTermina = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OdrzanoSati = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik_Trener", x => new { x.KorisnikID, x.TrenerID, x.DatumTermina });
                    table.ForeignKey(
                        name: "FK_Korisnik_Trener_Korisnik_KorisnikID",
                        column: x => x.KorisnikID,
                        principalTable: "Korisnik",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Korisnik_Trener_Trener_TrenerID",
                        column: x => x.TrenerID,
                        principalTable: "Trener",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Administrator",
                columns: new[] { "ID", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "admin", "admin" },
                    { 2, "host", "host" }
                });

            migrationBuilder.InsertData(
                table: "Clanarina",
                columns: new[] { "ID", "Cijena", "Naziv", "Opis" },
                values: new object[,]
                {
                    { 1, 50f, "Fit Plus", "Teretane predstavljaju oazu zdravlja pružajući nam prostor gdje možemo ojačati svoje tijelo i smanjiti stres. Članstvo u teretani nije samo ulaganje u tjelesno zdravlje već i putovanje prema boljoj verziji sebe." },
                    { 2, 40f, "Student Fit Plus", "Studentska članarina u teretani nije samo investicija u tjelesno zdravlje, već i u opću dobrobit studenata. Zahvaljujući ovim povlasticama, teretane postaju pristupačne za studente svih financijskih mogućnosti, čime se stvara zdraviji i sretniji studentski život. Zbog toga mi nudimo popust od čak 20% za sve studente!" },
                    { 3, 25f, "Partner Fit Duo", "Teretane nude posebne članarine za parove koje omogućuju partnerima da zajedno uživaju u prednostima vježbanja. Podijelite iznos jedne članarine i uživajte u jačanju tijela i uma!" }
                });

            migrationBuilder.InsertData(
                table: "Dobavljac",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "MUSCLE FREAK" },
                    { 2, "MUSCLETECH" },
                    { 3, "OPTIMUM NUTRITION" },
                    { 4, "SELF OMNINUTRITION" },
                    { 5, "CW-CHEMICAL WARFARE" },
                    { 6, "BSN" },
                    { 7, "CELLUCOR" },
                    { 8, "EVOLITE" },
                    { 9, "SUPERIOR" },
                    { 10, "TESLA" }
                });

            migrationBuilder.InsertData(
                table: "FAQ",
                columns: new[] { "ID", "Odgovor", "Pitanje" },
                values: new object[,]
                {
                    { 1, "Cijene mjesečnih članarina variraju ovisno o paketu koji odaberete. Imamo različite opcije  prilagođene različitim potrebama i budžetima. Detaljne informacije o cijenama možete pronaći na homepage pod sekcijom 'cjenovnik članarina'.", "Koliko košta članarina u vašoj teretani?" },
                    { 2, "Da, imamo stručne trenere koji vam mogu pomoći u postizanju vaših fitness ciljeva. Oni će raditi s vama kako bi razvili personalizirani plan vježbanja. Pored njih, imamo i naš tim nutricionista.", "Da li u sklopu teretane imate personalne trenere?" },
                    { 3, "Vrlo jednostavno! Posjetite našu recepciju, odaberite željeni paket i dobit ćete svoju člansku karticu!", "Kako da postanem član vaše teretane?" },
                    { 4, "Tačnu lokaciju naše teretane možete pogledati na homepage pod rubrikom 'kako do nas?'.", "Gdje se nalazi vaša teretana?" },
                    { 5, "Kupovinu suplemenata izvršavate putem sekcije suplementi, pomoću koje rezervišete vas proizvod koji nakon toga trebate preuzeti u našoj poslovnici te platiti po uzeću.", "Kako izvršiti kupovinu suplemenata?" }
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Banja Luka" },
                    { 2, "Bihać" },
                    { 3, "Bijeljina" },
                    { 4, "Bosnaska Krupa" },
                    { 5, "Cazin" },
                    { 6, "Čapljina" },
                    { 7, "Drventa" },
                    { 8, "Doboj" },
                    { 9, "Goražde" },
                    { 10, "Gračanica" },
                    { 11, "Gradačac" },
                    { 12, "Gradiška" },
                    { 13, "Konjic" },
                    { 14, "Laktaši" },
                    { 15, "Livno" },
                    { 16, "Lukavac" },
                    { 17, "Ljubuški" },
                    { 18, "Mostar" },
                    { 19, "Orašje" },
                    { 20, "Prijedor" },
                    { 21, "Prnjavor" },
                    { 22, "Sarajevo" }
                });

            migrationBuilder.InsertData(
                table: "Grad",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 23, "Srebrenik" },
                    { 24, "Stolac" },
                    { 25, "Široki Brijeg" },
                    { 26, "Travnik" },
                    { 27, "Tuzla" },
                    { 28, "Visoko" },
                    { 29, "Zavidovići" },
                    { 30, "Zenica" },
                    { 31, "Zvornik" },
                    { 32, "Živinice" }
                });

            migrationBuilder.InsertData(
                table: "Kategorija",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Proteini" },
                    { 2, "Amino kiseline" },
                    { 3, "Preworkout" },
                    { 4, "Mass gaineri" }
                });

            migrationBuilder.InsertData(
                table: "Nutricionist",
                columns: new[] { "ID", "BrojTelefona", "Ime", "Prezime", "Slika" },
                values: new object[,]
                {
                    { 1, "062709689", "Marijana", "Zubac", "assets/1nut.jpg" },
                    { 2, "062709689", "Amela", "Ivković", "assets/2nut.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Recenzija",
                columns: new[] { "ID", "Ime", "Prezime", "Slika", "Tekst", "Zanimanje" },
                values: new object[,]
                {
                    { 1, "Jusuf", "Nurkić", "assets/1rec.jpg", "Toplo preporučujem svima koji traže vrhunsku dvoranu za fitness. Osoblje je ljubazno i obrazovano, oprema i tereni su u izvrsnom stanju, a atmosfera jako motivirajuća. To je mjesto gdje možete postići svoje fitness ciljeve i pritom se osjećati sjajno. Pridruživanje ovoj teretani bila je jedna od najboljih odluka koje sam donio za svoje zdravlje i dobrobit.", "Košarkaš" },
                    { 2, "Miralem", "Pjanić", "assets/2rec.jpg", "Ako ste u potrazi za izvrsnom teretanom, ne tražite dalje. Dio sam ove porodice više od dvije godine i jako sam zadovoljan. Treneri su izvrsni, raznovrsnost opreme je impresivna, a sveukupno okruženje jako gostoljubivo. Vidio sam stvarne rezultate i osjećam se energičnije i sigurnije. Pridruživanje ovoj teretani bio je fantastičan izbor i ne mogu ga dovoljno preporučiti!", "Fudbaler" },
                    { 3, "Luka", "Modrić", "assets/3rec.jpg", "Svim srcem podržavam rad ovog postrojenja kao ultimativno odredište za trening. Od najsavremenije opreme do ljubaznog osoblja koje vam pruža podršku, ova teretana ima sve što vam je potrebno za postizanje vaših fitness ciljeva. Pozitivna i motivirajuća atmosfera tjera me da se vraćam i značajno sam napredovao u svom zdravlju i kondiciji otkako sam se pridružio. Nemojte se ustručavati postati dio ove fantastične zajednice – nećete požaliti!", "Fudbaler" },
                    { 4, "Luka", "Dončić", "assets/4rec.jpg", "Za uistinu izvanredno fitness iskustvo, ne mogu dovoljno preporučiti ovo mjesto. Ova teretana ima sve: dobro održavane sprave, stručne trenere i fantastičnu atmosferu. Vidio sam izvanredna poboljšanja u svojoj snazi i općem zdravlju otkako sam postao član. Ako tražite teretanu koja nadahnjuje i podržava vaše putovanje u fitness, onda je ovo pravo mjesto za vas. Pridruživanje je bila jedna od najboljih odluka koje sam donio za svoje zdravlje.", "Košarkaš" }
                });

            migrationBuilder.InsertData(
                table: "Seminar",
                columns: new[] { "ID", "Datum", "Predavac", "Tema" },
                values: new object[,]
                {
                    { 1, new DateTime(2022, 12, 10, 9, 15, 0, 0, DateTimeKind.Unspecified), "Maja Gradinjan", "Metabolički Sindrom" },
                    { 2, new DateTime(2023, 4, 12, 9, 15, 0, 0, DateTimeKind.Unspecified), "Darija Topić", "Pravilna prehrana u službi zdravlja i sportskog razvoja" },
                    { 3, new DateTime(2020, 1, 10, 9, 15, 0, 0, DateTimeKind.Unspecified), "Tatjana Popović", "Snaga u vama" },
                    { 4, new DateTime(2019, 12, 10, 9, 15, 0, 0, DateTimeKind.Unspecified), "Ivan Račić", "CrossFit Level 3" },
                    { 5, new DateTime(2017, 6, 10, 9, 15, 0, 0, DateTimeKind.Unspecified), "Petar Klančir", "Pro Bodybuilding" },
                    { 6, new DateTime(2022, 1, 1, 12, 15, 0, 0, DateTimeKind.Unspecified), "Almir Tunić", "Samoodbrana" }
                });

            migrationBuilder.InsertData(
                table: "Spol",
                columns: new[] { "ID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Muški" },
                    { 2, "Ženski" }
                });

            migrationBuilder.InsertData(
                table: "Trener",
                columns: new[] { "ID", "BrojTelefona", "Ime", "Prezime", "Slika" },
                values: new object[,]
                {
                    { 1, "0644076290", "Kadir", "Keskin", "assets/1tre.jpg" },
                    { 2, "0644076290", "Azur", "Kahriman", "assets/2tre.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Nutricionist_Seminar",
                columns: new[] { "NutricionistID", "SeminarID" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Suplement",
                columns: new[] { "ID", "Cijena", "DobavljacID", "Gramaza", "KategorijaID", "Naziv", "Opis", "Slika" },
                values: new object[,]
                {
                    { 1, 139f, 1, 2500f, 1, "100% Whey Protein", "Muscle Freak 100% Isolate Whey Protein je visokokvalitetni izolat proteina sirutke, koji smo kreirali kako bi zadovoljili potrebe i najzahtjevnijih vježbača. Nakon godina uspješnog rada i distribucije najvećih brendova na tržištu, mi u Muscle Freaku smo odlučili da je vrijeme da i naša linija proizvoda ugleda svjetlo dana i da vam u skladu s našom tradicijom ponudimo najbolje i najkvalitetnije proizvode s predznakom bosanski brend.", "assets/1sup.webp" },
                    { 2, 99f, 3, 809f, 1, "Gold 100% Casein", "Korištenjem samo vrhunskog kazeina kao izvora proteina u svom 100% Gold Standard Casein-u, Optimum Nutrition je stvorio formulu koja postavlja standard za sve sporootpuštajuće proteine.", "assets/2sup.webp" },
                    { 3, 89f, 2, 900f, 1, "Nitro-Tech Ripped", "NITRO-TECH RIPPED™ je najnovija inovacija iz MuscleTech-a, branda koji oduševljava svojim proizvodima više od 20 godina. Ova napredna formula kombinuje proteinske peptide najviše kvalitete i izolat sa naučno testiranim sastojcima za gubitak težine. Ova 7 u 1 formula također sadrži CLA, trigliceride srednjeg lanca (MCT), L-carnitine L-tartrate, ekstrakt zelenog čaja, ekstrakt šipka i prah algi. MuscleTech® je napravio ovu jedinstvenu formula s ciljem objedinjavanja ultra-čistog proteina i gubitka težine - ovakvo nešto niste nikad prije vidjeli. Za razliku od konkurencije, svaka mjerica NITRO-TECH RIPPED™ sadrži naučno proučavanu dozu ključnih sastojaka za gubitak težine, C. canephora robusta, koja je potvrđena od strane dvije naučne studije i u čije rezultate ne morate sumnjati! Također, nevjerovatnog je okusa koji će Vas oduševiti!", "assets/3sup.webp" },
                    { 4, 139f, 2, 1800f, 1, "Nitro-Tech Whey Protein", "NITRO-TECH® je naučno istražena, pojačana proteinska formula kreirana za sve sportiste koji žele veću mišićnu masu, više snage i bolje performanse. NITRO-TECH® sadrži protein čiji primarni izvor su peptidi i izolat sirutke – dva najčistija i najkvalitetnija dostupna izvora proteina, za razliku od ostalih proteinskih suplemenata koji možda sadrže tek par gama ovih lako probavljivih i visoke biološke vrijednosti proteina. NITRO-TECH® je takođe poboljšan i sa 3g kreatin monohidrata, najistraženijim oblikom kreatina, namjenjenim za još veću mišićnu masu i snagu.", "assets/4sup.webp" },
                    { 5, 89f, 2, 908f, 1, "Nitro-Tech 100% Whey", "Preko 20 godina NITRO-TECH® je vodeći proteinski brend, izgrađen na temelju naučnih istraživanja i korištenja najmodernije tehnologija. Sada je isti istraživački i razvojni tim stvorio novu formulu whey proteina baziranu na superiornim izvorima proteina, kvaliteti i tehnici proizvodnje. Predstavljamo vam NITRO-TECH® 100% WHEY GOLD – čistu proteinsku formulu koja sadrži peptide i izolat sirutke.", "assets/5sup.webp" },
                    { 6, 119f, 2, 2000f, 1, "Platinum 8", "Vrhunska proteinska mješavina za sve namjene u bilo koje vrijeme posebno formulirana za sportiste koji žele biti na vrhuncu svoje igre. Dizajniran s visokokvalitetnom, višefaznom mješavinom proteina, može se uzimati kad god je potrebno - nakon treninga, između obroka ili prije spavanja.", "assets/6sup.webp" },
                    { 7, 35f, 4, 250f, 2, "BCAA 2:1:1", "Vrhunski ukusan spoj esencijalnih aminokiselina. Ovaj proizvod ne samo da pruža izvanredan ukus, već je i obogaćen esencijalnim hranjivim sastojcima poput vitamina C i vitamina B6. BCAA je kritičan faktor koji vam može pomoći da postignete najbolje iz svojih treninga.", "assets/7sup.webp" },
                    { 8, 45f, 4, 900f, 2, "HMB", "Self Omninutrition HMB (beta-hidroksi-beta-metilbutirat) je metabolit leucina koji sprečava razgradnju proteina i promoviše hipertrofiju mišića (povećanje ćelija koje grade tkivo); također smanjuje moguće povrede mišića nakon treninga visokog intenziteta, čime se smanjuje postotak masnoće u tijelu. Nedavna istraživanja su također pokazala da uzimanje HMB povećava mišićnu snagu, smanjuje simptome prekomjernog treninga te pozitivno utiče na VO2max (maksimalna potrošnja kiseonika). Neki stručnjaci smatraju da je VO2max ključni faktor u sportskim takmičenjima sportista. HMB je vrijedan dodatak ishrani za snagu, performanse i izdržljivost.", "assets/8sup.webp" },
                    { 9, 75f, 2, 400f, 2, "Amino Build", "Napunjene sa gradivnim elementima kako bi podržale brz oporavak. Imajući u vidu da su BCAA kao osnova u sastavu, ubrzat će period oporavka poslije treninga.", "assets/9sup.webp" },
                    { 10, 85f, 2, 594f, 2, "Cell Tech Elite", "Cell Tech Elite je visoko potentna formula koja pruža vrhunsku dozu od 5 g kreatinske matrice, koja uključuje kreatin monohidrat i kreatin hidroklorid. Osim toga, ova formula sadrži klinički dokazanu dozu od 400 mg Peak ATP-a, koji omogućava povećanje snage i veći broj ponavljanja u treningu. U kliničkoj studiji je dokazano da su ispitanici koji su koristili Peak ATP izgradili 90% više mišića u poređenju sa placebom, postižući impresivne rezultate u roku od 12 sedmica intenzivnog treninga.", "assets/10sup.webp" },
                    { 11, 85f, 5, 480f, 2, "CW Intra Surgence", "CW Intra Surgence je naučno formuliran Intra-Workout dodatak koji pruža visoko doziranu mješavinu punog spektra esencijalnih aminokiselina (EAA) i razgranatih lanaca aminokiselina (BCAA), zajedno s najnovijim hidratacijskim sastojcima i patentiranim dodacima za povećanje energije.", "assets/11sup.webp" },
                    { 12, 65f, 6, 433f, 2, "Amino X", "Amino X je specijalna aminokiselinska formula dizajnirana da pomogne tijelu u povećanju izdržljivosti tokom treninga i mišićnom oporavku nakon treninga. Sadrži kvalitetnu anaboličku mješavinu, koja spriječava katabolizam (propadanje mišićnih vlakna) te se brine za obnovu i rast mišića.", "assets/12sup.webp" },
                    { 13, 65f, 1, 300f, 3, "Power Reactor", "Muscle Freak Power Reactor je visokokvalitetni pre-workout, koji smo kreirali kako bi zadovoljili potrebe i najzahtjevnijih vježbača. Nakon godina uspješnog rada i distribucije najvećih brendova na tržištu, mi u Muscle Freaku smo odlučili da je vrijeme da i naša linija proizvoda ugleda svjetlo dana i da vam u skladu s našom tradicijom ponudimo najbolje i najkvalitetnije proizvode s predznakom bosanski brend.", "assets/13sup.webp" },
                    { 14, 85f, 2, 420f, 3, "N.O.-Xplode Vaso", "Izgradnja mišića zahtijeva pravilnu ishranu i treninge. Mnogi suplementi prije treninga mogu pružiti energiju i fokus, ali rijetko isporučuju onu pravu \"pumpu\" koju tražite. Ali sada je vaša potraga gotova zahvaljujući N.O.-XPLODE VASO!", "assets/14sup.webp" },
                    { 15, 85f, 7, 410f, 3, "C4 Ultimate", "Cellucor C4 Ultimate je dugi niz godina usavršavao pre-workoute, mnogo prije nego neki drugi brendovi u industriji sportskih suplemenata. Gotovo desetljeće brend C4® bio je prvi u kategoriji pre-workouta sa učinkom i eksplozivnom energijom, najboljim okusima, klinički proučenim sastojcima i vrhunskim formulama.", "assets/15sup.webp" },
                    { 16, 65f, 7, 180f, 3, "C4 Ripped", "C4 Ripped sadrži sličnu energetsku mješavinu kao i klasični C4, s ključnim sastojcima za energiju koji će vam pomoći da prođete kroz najteže vježbe.", "assets/16sup.webp" },
                    { 17, 69f, 6, 390f, 3, "N.O.-Xplode", "N.O.-XPLODE pomaže u održavanju mentalne budnosti i mišićne snage, donosi energiju i izdržljivost te pomaže sportistima poboljšati kapacitet na svim razinama.", "assets/17sup.webp" },
                    { 18, 69f, 2, 363f, 3, "Shatter", "MuscleTech Shatter™ je iznimno snažan i naučno osmišljen pre-workout suplement koji će Vam doslovno razderati majicu i poboljšati vaše performanse snage i izdržljivosti. Ova vrhunska formula pruža i snažnu energiju i kompleks koji će Vas potaknuti kroz svaki trening.", "assets/18sup.webp" },
                    { 19, 79f, 1, 1200f, 4, "Mega Mass", "Muscle Freak Mega Mass je visokokvalitetni gainer, koji smo kreirali kako bi zadovoljili potrebe i najzahtjevnijih vježbača. Nakon godina uspješnog rada i distribucije najvećih brendova na tržištu, mi u Muscle Freaku smo odlučili da je vrijeme da i naša linija proizvoda ugleda svjetlo dana i da vam u skladu s našom tradicijom ponudimo najbolje i najkvalitetnije proizvode s predznakom bosanski brend.", "assets/19sup.webp" },
                    { 20, 119f, 2, 3200f, 4, "Mass Tech ELITE", "Mass-Tech Elite je napredni mass gainer za one koji imaju problemasa povećanjem veličine ili žele da probiju svoje platoe snage...", "assets/20sup.webp" },
                    { 21, 89f, 2, 2300f, 4, "100% Mass Gainer", "Iz najbolje američke kompanije za prodaju suplemenata, MuscleTech predstavlja Vam 100% Mass Gainer - visokoproteinski suplement za povećanje mišične mase. Ovaj dodatak, obogaćen prirodnim i umjetnim aromama, pruža Vam sve što je potrebno da unaprijedite mišiće, snagu i performanse, uz brži oporavak mišića.", "assets/21sup.webp" },
                    { 22, 75f, 10, 2270f, 4, "Mass Super Charger", "Tesla Mass Super Charger može pomoći vašim mišićima da rastu, zahvaljujući  ugljikohidratima iz više izvora, visokom sadržaju proteina i dodatku aminokiselina u optimalnom omjeru 2:1:1 za pomoć u iskorištavanju proteina. Kreatin je također dodat kako bi pomogao da se mišići napune vodom i potakne daljnji rast, zajedno s pažljivo odabranim vitaminskim kompleksom koji podržava sposobnost vašeg tijela da koristi proteine ​​i ugljikohidrate za energiju i čistu mišićnu masu.", "assets/22sup.webp" },
                    { 23, 119f, 8, 1000f, 4, "IsoGainz", "Evolite IsoGainz je ugljikohidratno-proteinski suplement visoke kvalitete namijenjen prvenstveno aktivnim osobama koji se sastoji od: odabrani ugljikohidrati (maltodextrin sa jako malim sadržajem šećera) proteina (izolat I koncentrat koji ne sadrže laktozu) .Proizvod se može koristiti kao dodatak svakodnevnoj prehrani. Idealno prikladan za korištenje nakon treninga kako bi se nadoknadile zalihe energije u mišićima. Protein doprinosi rastu mišične mase I pomaže u njenom održavanju.", "assets/23sup.png" },
                    { 24, 159f, 9, 8000f, 4, "Hyper Mass", "Hyper Mass Professional je izuzetno moćan suplement s bogatim vitaminskim kompleksom, namijenjen da vam pomogne postići vaše ciljeve u izgradnji mišića! Ovaj preparat Hyper Mass, sa svojom vrhunskom kombinacijom sastojaka, idealan je izbor za sve koji žele dodati mišićnu masu, povećati snagu i izdržljivost tokom treninga.", "assets/24sup.webp" }
                });

            migrationBuilder.InsertData(
                table: "Teretana",
                columns: new[] { "ID", "Adresa", "GradID", "Naziv" },
                values: new object[,]
                {
                    { 1, "Patriotske lige bb", 22, "ProGym Fitness Centar" },
                    { 2, "Novo naselje Zalik bb", 18, "Bodyline Mostar" },
                    { 3, "Turalibegova 25a", 27, "Body Control" },
                    { 4, "Veljka Mlađenovića bb", 1, "Blue Line Fitness" },
                    { 5, "Trg Alije Izetbegovića 86", 30, "ZEFIT Gym" },
                    { 6, "Sarajevska k-1", 2, "Reflex Gym" },
                    { 7, "Željeznička 2, Konjic", 13, "No Limits Gym" }
                });

            migrationBuilder.InsertData(
                table: "Trener_Seminar",
                columns: new[] { "SeminarID", "TrenerID" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 6, 1 },
                    { 4, 2 },
                    { 6, 2 }
                });

            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "ID", "BrojTelefona", "GradID", "Ime", "Password", "Prezime", "Slika", "SpolID", "TeretanaID", "Tezina", "Username", "Visina" },
                values: new object[,]
                {
                    { 1, "0644076290", 18, "Vedad", "bayern123", "Keskin", "assets/1kor.png", 1, 2, 80f, "vedadke", 170f },
                    { 2, "062709689", 26, "Džejla", "fit2023", "Palalić", "assets/2kor.jpg", 2, 2, 57f, "dzejlap", 164f },
                    { 3, "0644065144", 18, "Said", "fit2023", "Keskin", "assets/3kor.jpg", 1, 2, 62f, "saidke", 180f },
                    { 4, "061000000", 5, "Denis", "user", "Mušić", "assets/4kor.jpg", 1, 2, 79f, "denism", 186f },
                    { 5, "062000000", 7, "Adil", "user", "Joldić", "assets/5kor.jpg", 1, 2, 75f, "adilj", 184f }
                });

            migrationBuilder.InsertData(
                table: "Korisnik_Clanarina",
                columns: new[] { "ClanarinaID", "DatumUplate", "KorisnikID", "DatumIsteka" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2023, 10, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 1, new DateTime(2023, 10, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 9, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 10, 1, 9, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 10, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 12, 1, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 9, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 10, 1, 9, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 10, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 12, 1, 7, 15, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_GradID",
                table: "Korisnik",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_SpolID",
                table: "Korisnik",
                column: "SpolID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_TeretanaID",
                table: "Korisnik",
                column: "TeretanaID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_Clanarina_KorisnikID",
                table: "Korisnik_Clanarina",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_Nutricionst_NutricionistID",
                table: "Korisnik_Nutricionst",
                column: "NutricionistID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_Suplement_KorisnikID",
                table: "Korisnik_Suplement",
                column: "KorisnikID");

            migrationBuilder.CreateIndex(
                name: "IX_Korisnik_Trener_TrenerID",
                table: "Korisnik_Trener",
                column: "TrenerID");

            migrationBuilder.CreateIndex(
                name: "IX_Nutricionist_Seminar_SeminarID",
                table: "Nutricionist_Seminar",
                column: "SeminarID");

            migrationBuilder.CreateIndex(
                name: "IX_Suplement_DobavljacID",
                table: "Suplement",
                column: "DobavljacID");

            migrationBuilder.CreateIndex(
                name: "IX_Suplement_KategorijaID",
                table: "Suplement",
                column: "KategorijaID");

            migrationBuilder.CreateIndex(
                name: "IX_Teretana_GradID",
                table: "Teretana",
                column: "GradID");

            migrationBuilder.CreateIndex(
                name: "IX_Trener_Seminar_SeminarID",
                table: "Trener_Seminar",
                column: "SeminarID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrator");

            migrationBuilder.DropTable(
                name: "FAQ");

            migrationBuilder.DropTable(
                name: "Korisnik_Clanarina");

            migrationBuilder.DropTable(
                name: "Korisnik_Nutricionst");

            migrationBuilder.DropTable(
                name: "Korisnik_Suplement");

            migrationBuilder.DropTable(
                name: "Korisnik_Trener");

            migrationBuilder.DropTable(
                name: "Nutricionist_Seminar");

            migrationBuilder.DropTable(
                name: "Recenzija");

            migrationBuilder.DropTable(
                name: "Trener_Seminar");

            migrationBuilder.DropTable(
                name: "Clanarina");

            migrationBuilder.DropTable(
                name: "Suplement");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "Nutricionist");

            migrationBuilder.DropTable(
                name: "Seminar");

            migrationBuilder.DropTable(
                name: "Trener");

            migrationBuilder.DropTable(
                name: "Dobavljac");

            migrationBuilder.DropTable(
                name: "Kategorija");

            migrationBuilder.DropTable(
                name: "Spol");

            migrationBuilder.DropTable(
                name: "Teretana");

            migrationBuilder.DropTable(
                name: "Grad");
        }
    }
}
