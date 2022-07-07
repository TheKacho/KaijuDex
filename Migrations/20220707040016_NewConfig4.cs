using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KaijuDex.Migrations
{
    public partial class NewConfig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "ImageURL",
                table: "Monsters");

            migrationBuilder.AddColumn<string>(
                name: "SpecialAttack",
                table: "Monsters",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialAttack",
                table: "Monsters");

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Movies",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageURL",
                table: "Monsters",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
