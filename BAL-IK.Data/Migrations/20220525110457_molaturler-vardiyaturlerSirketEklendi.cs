using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAL_IK.Data.Migrations
{
    public partial class molaturlervardiyaturlerSirketEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MolaSuresi",
                table: "Molalar");

            migrationBuilder.AddColumn<int>(
                name: "SirketId",
                table: "VardiyaTur",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "MolaSuresi",
                table: "MolaTur",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "SirketId",
                table: "MolaTur",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SiteYoneticileri",
                keyColumn: "SiteYoneticisiId",
                keyValue: 1,
                column: "DogumTarihi",
                value: new DateTime(2022, 5, 25, 14, 4, 56, 907, DateTimeKind.Local).AddTicks(3219));

            migrationBuilder.CreateIndex(
                name: "IX_VardiyaTur_SirketId",
                table: "VardiyaTur",
                column: "SirketId");

            migrationBuilder.CreateIndex(
                name: "IX_MolaTur_SirketId",
                table: "MolaTur",
                column: "SirketId");

            migrationBuilder.AddForeignKey(
                name: "FK_MolaTur_Sirketler_SirketId",
                table: "MolaTur",
                column: "SirketId",
                principalTable: "Sirketler",
                principalColumn: "SirketId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VardiyaTur_Sirketler_SirketId",
                table: "VardiyaTur",
                column: "SirketId",
                principalTable: "Sirketler",
                principalColumn: "SirketId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MolaTur_Sirketler_SirketId",
                table: "MolaTur");

            migrationBuilder.DropForeignKey(
                name: "FK_VardiyaTur_Sirketler_SirketId",
                table: "VardiyaTur");

            migrationBuilder.DropIndex(
                name: "IX_VardiyaTur_SirketId",
                table: "VardiyaTur");

            migrationBuilder.DropIndex(
                name: "IX_MolaTur_SirketId",
                table: "MolaTur");

            migrationBuilder.DropColumn(
                name: "SirketId",
                table: "VardiyaTur");

            migrationBuilder.DropColumn(
                name: "MolaSuresi",
                table: "MolaTur");

            migrationBuilder.DropColumn(
                name: "SirketId",
                table: "MolaTur");

            migrationBuilder.AddColumn<double>(
                name: "MolaSuresi",
                table: "Molalar",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "SiteYoneticileri",
                keyColumn: "SiteYoneticisiId",
                keyValue: 1,
                column: "DogumTarihi",
                value: new DateTime(2022, 5, 25, 13, 48, 8, 325, DateTimeKind.Local).AddTicks(2091));
        }
    }
}
