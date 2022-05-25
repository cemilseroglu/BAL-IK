using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAL_IK.Data.Migrations
{
    public partial class Izinler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izinler_SirketYoneticileri_SirketYoneticisiId",
                table: "Izinler");

            migrationBuilder.AlterColumn<int>(
                name: "SirketYoneticisiId",
                table: "Izinler",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ReddilmeNedeni",
                table: "Izinler",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OnaylanmaTarihi",
                table: "Izinler",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "SiteYoneticileri",
                keyColumn: "SiteYoneticisiId",
                keyValue: 1,
                column: "DogumTarihi",
                value: new DateTime(2022, 5, 23, 17, 11, 48, 69, DateTimeKind.Local).AddTicks(1049));

            migrationBuilder.AddForeignKey(
                name: "FK_Izinler_SirketYoneticileri_SirketYoneticisiId",
                table: "Izinler",
                column: "SirketYoneticisiId",
                principalTable: "SirketYoneticileri",
                principalColumn: "SirketYoneticisiId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Izinler_SirketYoneticileri_SirketYoneticisiId",
                table: "Izinler");

            migrationBuilder.AlterColumn<int>(
                name: "SirketYoneticisiId",
                table: "Izinler",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ReddilmeNedeni",
                table: "Izinler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OnaylanmaTarihi",
                table: "Izinler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "SiteYoneticileri",
                keyColumn: "SiteYoneticisiId",
                keyValue: 1,
                column: "DogumTarihi",
                value: new DateTime(2022, 5, 22, 14, 34, 14, 2, DateTimeKind.Local).AddTicks(7759));

            migrationBuilder.AddForeignKey(
                name: "FK_Izinler_SirketYoneticileri_SirketYoneticisiId",
                table: "Izinler",
                column: "SirketYoneticisiId",
                principalTable: "SirketYoneticileri",
                principalColumn: "SirketYoneticisiId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
