using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAL_IK.Data.Migrations
{
    public partial class MolavePersonelIdeklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Vardiyalar_VardiyaId",
                table: "Personeller");

            migrationBuilder.DropTable(
                name: "MolaPersoneller");

            migrationBuilder.DropIndex(
                name: "IX_Personeller_VardiyaId",
                table: "Personeller");

            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "Molalar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "SiteYoneticileri",
                keyColumn: "SiteYoneticisiId",
                keyValue: 1,
                column: "DogumTarihi",
                value: new DateTime(2022, 5, 25, 15, 28, 55, 312, DateTimeKind.Local).AddTicks(909));

            migrationBuilder.CreateIndex(
                name: "IX_Vardiyalar_PersonelId",
                table: "Vardiyalar",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Molalar_PersonelId",
                table: "Molalar",
                column: "PersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Molalar_Personeller_PersonelId",
                table: "Molalar",
                column: "PersonelId",
                principalTable: "Personeller",
                principalColumn: "PersonelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vardiyalar_Personeller_PersonelId",
                table: "Vardiyalar",
                column: "PersonelId",
                principalTable: "Personeller",
                principalColumn: "PersonelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Molalar_Personeller_PersonelId",
                table: "Molalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Vardiyalar_Personeller_PersonelId",
                table: "Vardiyalar");

            migrationBuilder.DropIndex(
                name: "IX_Vardiyalar_PersonelId",
                table: "Vardiyalar");

            migrationBuilder.DropIndex(
                name: "IX_Molalar_PersonelId",
                table: "Molalar");

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "Molalar");

            migrationBuilder.CreateTable(
                name: "MolaPersoneller",
                columns: table => new
                {
                    MolalarMolaId = table.Column<int>(type: "int", nullable: false),
                    PersonellerPersonelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MolaPersoneller", x => new { x.MolalarMolaId, x.PersonellerPersonelId });
                    table.ForeignKey(
                        name: "FK_MolaPersoneller_Molalar_MolalarMolaId",
                        column: x => x.MolalarMolaId,
                        principalTable: "Molalar",
                        principalColumn: "MolaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MolaPersoneller_Personeller_PersonellerPersonelId",
                        column: x => x.PersonellerPersonelId,
                        principalTable: "Personeller",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "SiteYoneticileri",
                keyColumn: "SiteYoneticisiId",
                keyValue: 1,
                column: "DogumTarihi",
                value: new DateTime(2022, 5, 25, 14, 4, 56, 907, DateTimeKind.Local).AddTicks(3219));

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_VardiyaId",
                table: "Personeller",
                column: "VardiyaId");

            migrationBuilder.CreateIndex(
                name: "IX_MolaPersoneller_PersonellerPersonelId",
                table: "MolaPersoneller",
                column: "PersonellerPersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Vardiyalar_VardiyaId",
                table: "Personeller",
                column: "VardiyaId",
                principalTable: "Vardiyalar",
                principalColumn: "VardiyaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
