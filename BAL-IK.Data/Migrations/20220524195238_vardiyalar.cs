using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAL_IK.Data.Migrations
{
    public partial class vardiyalar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "Vardiyalar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SiteYoneticileri",
                keyColumn: "SiteYoneticisiId",
                keyValue: 1,
                column: "DogumTarihi",
                value: new DateTime(2022, 5, 24, 22, 52, 38, 4, DateTimeKind.Local).AddTicks(7179));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "Vardiyalar");

            migrationBuilder.UpdateData(
                table: "SiteYoneticileri",
                keyColumn: "SiteYoneticisiId",
                keyValue: 1,
                column: "DogumTarihi",
                value: new DateTime(2022, 5, 23, 17, 11, 48, 69, DateTimeKind.Local).AddTicks(1049));
        }
    }
}
