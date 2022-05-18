using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAL_IK.Data.Migrations
{
    public partial class denemeDummuySiteAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SiteYoneticileri",
                columns: new[] { "SiteYoneticisiId", "Ad", "AktifMi", "Cinsiyet", "DogumTarihi", "Eposta", "Guid", "ResimUrl", "Sifre", "Soyad" },
                values: new object[] { 1, "BALIK", true, 0, new DateTime(2022, 5, 17, 17, 49, 3, 770, DateTimeKind.Local).AddTicks(2493), "admin@bal-ik.com", new Guid("c96ce224-3473-4d45-93fd-56b5f1d594ac"), null, "123456", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SiteYoneticileri",
                keyColumn: "SiteYoneticisiId",
                keyValue: 1);
        }
    }
}
