using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAL_IK.Data.Migrations
{
    public partial class VardiyaTurDuzelnedi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VardiyaBaslangicTarihi",
                table: "Vardiyalar");

            migrationBuilder.DropColumn(
                name: "VardiyaBitisTarihi",
                table: "Vardiyalar");

            migrationBuilder.AddColumn<DateTime>(
                name: "VardiyaBaslangicTarihi",
                table: "VardiyaTur",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "VardiyaBitisTarihi",
                table: "VardiyaTur",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SiteYoneticileri",
                keyColumn: "SiteYoneticisiId",
                keyValue: 1,
                column: "DogumTarihi",
                value: new DateTime(2022, 5, 25, 13, 48, 8, 325, DateTimeKind.Local).AddTicks(2091));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VardiyaBaslangicTarihi",
                table: "VardiyaTur");

            migrationBuilder.DropColumn(
                name: "VardiyaBitisTarihi",
                table: "VardiyaTur");

            migrationBuilder.AddColumn<DateTime>(
                name: "VardiyaBaslangicTarihi",
                table: "Vardiyalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "VardiyaBitisTarihi",
                table: "Vardiyalar",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "SiteYoneticileri",
                keyColumn: "SiteYoneticisiId",
                keyValue: 1,
                column: "DogumTarihi",
                value: new DateTime(2022, 5, 24, 22, 52, 38, 4, DateTimeKind.Local).AddTicks(7179));
        }
    }
}
