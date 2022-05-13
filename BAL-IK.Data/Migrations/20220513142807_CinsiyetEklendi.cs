using Microsoft.EntityFrameworkCore.Migrations;

namespace BAL_IK.Data.Migrations
{
    public partial class CinsiyetEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cinsiyet",
                table: "SiteYoneticileri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cinsiyet",
                table: "SirketYoneticileri",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cinsiyet",
                table: "Personeller",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cinsiyet",
                table: "SiteYoneticileri");

            migrationBuilder.DropColumn(
                name: "Cinsiyet",
                table: "SirketYoneticileri");

            migrationBuilder.DropColumn(
                name: "Cinsiyet",
                table: "Personeller");
        }
    }
}
