using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMS.Migrations
{
    public partial class twoFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is2FActive",
                table: "KorisnickiNalog",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOtkljucano",
                table: "AutentifikacijaToken",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TwoFKey",
                table: "AutentifikacijaToken",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is2FActive",
                table: "KorisnickiNalog");

            migrationBuilder.DropColumn(
                name: "IsOtkljucano",
                table: "AutentifikacijaToken");

            migrationBuilder.DropColumn(
                name: "TwoFKey",
                table: "AutentifikacijaToken");
        }
    }
}
