using Microsoft.EntityFrameworkCore.Migrations;

namespace BAL_IK.Data.Migrations
{
    public partial class personellerdepartmanvevardiyaidzorunlulugukaldirildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Departmanlar_DepartmanId",
                table: "Personeller");

            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Vardiyalar_VardiyaId",
                table: "Personeller");

            migrationBuilder.AlterColumn<int>(
                name: "VardiyaId",
                table: "Personeller",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmanId",
                table: "Personeller",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Departmanlar_DepartmanId",
                table: "Personeller",
                column: "DepartmanId",
                principalTable: "Departmanlar",
                principalColumn: "DepartmanId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Vardiyalar_VardiyaId",
                table: "Personeller",
                column: "VardiyaId",
                principalTable: "Vardiyalar",
                principalColumn: "VardiyaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Departmanlar_DepartmanId",
                table: "Personeller");

            migrationBuilder.DropForeignKey(
                name: "FK_Personeller_Vardiyalar_VardiyaId",
                table: "Personeller");

            migrationBuilder.AlterColumn<int>(
                name: "VardiyaId",
                table: "Personeller",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmanId",
                table: "Personeller",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Departmanlar_DepartmanId",
                table: "Personeller",
                column: "DepartmanId",
                principalTable: "Departmanlar",
                principalColumn: "DepartmanId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personeller_Vardiyalar_VardiyaId",
                table: "Personeller",
                column: "VardiyaId",
                principalTable: "Vardiyalar",
                principalColumn: "VardiyaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
