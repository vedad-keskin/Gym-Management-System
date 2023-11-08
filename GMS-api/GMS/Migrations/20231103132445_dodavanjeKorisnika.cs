using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMS.Migrations
{
    public partial class dodavanjeKorisnika : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Korisnik",
                columns: new[] { "ID", "BrojTelefona", "GradID", "Ime", "Password", "Prezime", "SpolID", "TeretanaID", "Tezina", "Username", "Visina" },
                values: new object[,]
                {
                    { 3, "0644065144", 18, "Said", "fit2023", "Keskin", 1, 2, 62f, "saidke", 180f },
                    { 4, "061000000", 5, "Denis", "user", "Mušić", 1, 2, 79f, "denism", 186f },
                    { 5, "062000000", 7, "Adil", "user", "Joldić", 1, 2, 75f, "adilj", 184f }
                });

            migrationBuilder.InsertData(
                table: "Korisnik_Clanarina",
                columns: new[] { "ClanarinaID", "DatumUplate", "KorisnikID", "DatumIsteka" },
                values: new object[,]
                {
                    { 2, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 12, 1, 7, 15, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 12, 1, 7, 15, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Korisnik_Clanarina",
                columns: new[] { "ClanarinaID", "DatumUplate", "KorisnikID", "DatumIsteka" },
                values: new object[] { 1, new DateTime(2023, 10, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Korisnik_Clanarina",
                columns: new[] { "ClanarinaID", "DatumUplate", "KorisnikID", "DatumIsteka" },
                values: new object[] { 1, new DateTime(2023, 10, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 5, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Korisnik_Clanarina",
                columns: new[] { "ClanarinaID", "DatumUplate", "KorisnikID", "DatumIsteka" },
                values: new object[] { 4, new DateTime(2023, 10, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Korisnik_Clanarina",
                keyColumns: new[] { "ClanarinaID", "DatumUplate", "KorisnikID" },
                keyValues: new object[] { 1, new DateTime(2023, 10, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 4 });

            migrationBuilder.DeleteData(
                table: "Korisnik_Clanarina",
                keyColumns: new[] { "ClanarinaID", "DatumUplate", "KorisnikID" },
                keyValues: new object[] { 1, new DateTime(2023, 10, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 5 });

            migrationBuilder.DeleteData(
                table: "Korisnik_Clanarina",
                keyColumns: new[] { "ClanarinaID", "DatumUplate", "KorisnikID" },
                keyValues: new object[] { 2, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.DeleteData(
                table: "Korisnik_Clanarina",
                keyColumns: new[] { "ClanarinaID", "DatumUplate", "KorisnikID" },
                keyValues: new object[] { 2, new DateTime(2023, 11, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.DeleteData(
                table: "Korisnik_Clanarina",
                keyColumns: new[] { "ClanarinaID", "DatumUplate", "KorisnikID" },
                keyValues: new object[] { 4, new DateTime(2023, 10, 1, 7, 15, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.DeleteData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Korisnik",
                keyColumn: "ID",
                keyValue: 5);
        }
    }
}
