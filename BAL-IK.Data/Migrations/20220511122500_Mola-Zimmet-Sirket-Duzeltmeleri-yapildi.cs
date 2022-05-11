using Microsoft.EntityFrameworkCore.Migrations;

namespace BAL_IK.Data.Migrations
{
    public partial class MolaZimmetSirketDuzeltmeleriyapildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "Vardiyalar");

            migrationBuilder.DropColumn(
                name: "MolaAdi",
                table: "Molalar");

            migrationBuilder.RenameColumn(
                name: "VardiyaTuru",
                table: "Vardiyalar",
                newName: "VardiyaTurId");

            migrationBuilder.RenameColumn(
                name: "PersonelId",
                table: "Molalar",
                newName: "MolaTurId");

            migrationBuilder.RenameIndex(
                name: "IX_Molalar_PersonelId",
                table: "Molalar",
                newName: "IX_Molalar_MolaTurId");

            migrationBuilder.AddColumn<int>(
                name: "OdemePlani",
                table: "Sirketler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VardiyaId",
                table: "Personeller",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateTable(
                name: "MolaTur",
                columns: table => new
                {
                    MolaTurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MolaTuru = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MolaTur", x => x.MolaTurId);
                });

            migrationBuilder.CreateTable(
                name: "VardiyaTur",
                columns: table => new
                {
                    VardiyaTurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VardiyaTuru = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VardiyaTur", x => x.VardiyaTurId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vardiyalar_VardiyaTurId",
                table: "Vardiyalar",
                column: "VardiyaTurId");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_VardiyaId",
                table: "Personeller",
                column: "VardiyaId");

            migrationBuilder.CreateIndex(
                name: "IX_MolaPersoneller_PersonellerPersonelId",
                table: "MolaPersoneller",
                column: "PersonellerPersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Molalar_MolaTur_MolaTurId",
                table: "Molalar",
                column: "MolaTurId",
                principalTable: "MolaTur",
                principalColumn: "MolaTurId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Vardiyalar_VardiyaId",
                table: "Personeller",
                column: "VardiyaId",
                principalTable: "Vardiyalar",
                principalColumn: "VardiyaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vardiyalar_VardiyaTur_VardiyaTurId",
                table: "Vardiyalar",
                column: "VardiyaTurId",
                principalTable: "VardiyaTur",
                principalColumn: "VardiyaTurId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Molalar_MolaTur_MolaTurId",
                table: "Molalar");

            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Vardiyalar_VardiyaId",
                table: "Personeller");

            migrationBuilder.DropForeignKey(
                name: "FK_Vardiyalar_VardiyaTur_VardiyaTurId",
                table: "Vardiyalar");

            migrationBuilder.DropTable(
                name: "MolaPersoneller");

            migrationBuilder.DropTable(
                name: "MolaTur");

            migrationBuilder.DropTable(
                name: "VardiyaTur");

            migrationBuilder.DropIndex(
                name: "IX_Vardiyalar_VardiyaTurId",
                table: "Vardiyalar");

            migrationBuilder.DropIndex(
                name: "IX_Personeller_VardiyaId",
                table: "Personeller");

            migrationBuilder.DropColumn(
                name: "OdemePlani",
                table: "Sirketler");

            migrationBuilder.DropColumn(
                name: "VardiyaId",
                table: "Personeller");

            migrationBuilder.RenameColumn(
                name: "VardiyaTurId",
                table: "Vardiyalar",
                newName: "VardiyaTuru");

            migrationBuilder.RenameColumn(
                name: "MolaTurId",
                table: "Molalar",
                newName: "PersonelId");

            migrationBuilder.RenameIndex(
                name: "IX_Molalar_MolaTurId",
                table: "Molalar",
                newName: "IX_Molalar_PersonelId");

            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "Vardiyalar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MolaAdi",
                table: "Molalar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vardiyalar_PersonelId",
                table: "Vardiyalar",
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
    }
}
