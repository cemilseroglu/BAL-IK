using Microsoft.EntityFrameworkCore.Migrations;

namespace BAL_IK.Data.Migrations
{
    public partial class SirketYoneticisiSirketIdRequiredKaldirildi2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SirketYoneticileri_Sirketler_SirketId",
                table: "SirketYoneticileri");

            migrationBuilder.AlterColumn<int>(
                name: "SirketId",
                table: "SirketYoneticileri",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_SirketYoneticileri_Sirketler_SirketId",
                table: "SirketYoneticileri",
                column: "SirketId",
                principalTable: "Sirketler",
                principalColumn: "SirketId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SirketYoneticileri_Sirketler_SirketId",
                table: "SirketYoneticileri");

            migrationBuilder.AlterColumn<int>(
                name: "SirketId",
                table: "SirketYoneticileri",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SirketYoneticileri_Sirketler_SirketId",
                table: "SirketYoneticileri",
                column: "SirketId",
                principalTable: "Sirketler",
                principalColumn: "SirketId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
