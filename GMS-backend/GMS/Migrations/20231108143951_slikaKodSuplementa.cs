using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMS.Migrations
{
    public partial class slikaKodSuplementa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slika",
                table: "Suplement",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Suplement");
        }
    }
}
