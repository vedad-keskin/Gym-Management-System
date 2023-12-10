using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMS.Migrations
{
    public partial class TblZaLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogKretanjePoSistemu_KorisnickiNalog_korisnikID",
                table: "LogKretanjePoSistemu");

            migrationBuilder.RenameColumn(
                name: "vrijeme",
                table: "LogKretanjePoSistemu",
                newName: "Vrijeme");

            migrationBuilder.RenameColumn(
                name: "queryPath",
                table: "LogKretanjePoSistemu",
                newName: "QueryPath");

            migrationBuilder.RenameColumn(
                name: "postData",
                table: "LogKretanjePoSistemu",
                newName: "PostData");

            migrationBuilder.RenameColumn(
                name: "korisnikID",
                table: "LogKretanjePoSistemu",
                newName: "KorisnikID");

            migrationBuilder.RenameColumn(
                name: "isException",
                table: "LogKretanjePoSistemu",
                newName: "IsException");

            migrationBuilder.RenameColumn(
                name: "ipAdresa",
                table: "LogKretanjePoSistemu",
                newName: "IpAdresa");

            migrationBuilder.RenameColumn(
                name: "exceptionMessage",
                table: "LogKretanjePoSistemu",
                newName: "ExceptionMessage");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "LogKretanjePoSistemu",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_LogKretanjePoSistemu_korisnikID",
                table: "LogKretanjePoSistemu",
                newName: "IX_LogKretanjePoSistemu_KorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_LogKretanjePoSistemu_KorisnickiNalog_KorisnikID",
                table: "LogKretanjePoSistemu",
                column: "KorisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogKretanjePoSistemu_KorisnickiNalog_KorisnikID",
                table: "LogKretanjePoSistemu");

            migrationBuilder.RenameColumn(
                name: "Vrijeme",
                table: "LogKretanjePoSistemu",
                newName: "vrijeme");

            migrationBuilder.RenameColumn(
                name: "QueryPath",
                table: "LogKretanjePoSistemu",
                newName: "queryPath");

            migrationBuilder.RenameColumn(
                name: "PostData",
                table: "LogKretanjePoSistemu",
                newName: "postData");

            migrationBuilder.RenameColumn(
                name: "KorisnikID",
                table: "LogKretanjePoSistemu",
                newName: "korisnikID");

            migrationBuilder.RenameColumn(
                name: "IsException",
                table: "LogKretanjePoSistemu",
                newName: "isException");

            migrationBuilder.RenameColumn(
                name: "IpAdresa",
                table: "LogKretanjePoSistemu",
                newName: "ipAdresa");

            migrationBuilder.RenameColumn(
                name: "ExceptionMessage",
                table: "LogKretanjePoSistemu",
                newName: "exceptionMessage");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "LogKretanjePoSistemu",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_LogKretanjePoSistemu_KorisnikID",
                table: "LogKretanjePoSistemu",
                newName: "IX_LogKretanjePoSistemu_korisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_LogKretanjePoSistemu_KorisnickiNalog_korisnikID",
                table: "LogKretanjePoSistemu",
                column: "korisnikID",
                principalTable: "KorisnickiNalog",
                principalColumn: "ID");
        }
    }
}
