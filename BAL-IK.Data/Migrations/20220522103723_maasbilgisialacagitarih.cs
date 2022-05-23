using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAL_IK.Data.Migrations
{
    public partial class maasbilgisialacagitarih : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VerilisTarihi",
                table: "MaasBilgileri",
                newName: "AlacagiTarih");

            migrationBuilder.UpdateData(
                table: "SiteYoneticileri",
                keyColumn: "SiteYoneticisiId",
                keyValue: 1,
                column: "DogumTarihi",
                value: new DateTime(2022, 5, 22, 13, 37, 23, 88, DateTimeKind.Local).AddTicks(9405));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AlacagiTarih",
                table: "MaasBilgileri",
                newName: "VerilisTarihi");

            migrationBuilder.UpdateData(
                table: "SiteYoneticileri",
                keyColumn: "SiteYoneticisiId",
                keyValue: 1,
                column: "DogumTarihi",
                value: new DateTime(2022, 5, 22, 13, 29, 33, 552, DateTimeKind.Local).AddTicks(9050));
        }
    }
}
