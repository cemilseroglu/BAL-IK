using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BAL_IK.Data.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IzinTurleri",
                columns: table => new
                {
                    IzinTurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IzinTur = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IzinTurleri", x => x.IzinTurId);
                });

            migrationBuilder.CreateTable(
                name: "PrimTurleri",
                columns: table => new
                {
                    PrimTuruId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimTur = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimTurleri", x => x.PrimTuruId);
                });

            migrationBuilder.CreateTable(
                name: "Sirketler",
                columns: table => new
                {
                    SirketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SirketAdresi = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SirketTelefonu = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    SirketEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SirketLogoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Durum = table.Column<int>(type: "int", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UyelikBitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sirketler", x => x.SirketId);
                });

            migrationBuilder.CreateTable(
                name: "SiteYoneticileri",
                columns: table => new
                {
                    SiteYoneticisiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteYoneticileri", x => x.SiteYoneticisiId);
                });

            migrationBuilder.CreateTable(
                name: "ZimmetTurleri",
                columns: table => new
                {
                    ZimmetTuruId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZimmetTur = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZimmetTurleri", x => x.ZimmetTuruId);
                });

            migrationBuilder.CreateTable(
                name: "Departmanlar",
                columns: table => new
                {
                    DepartmanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmanAdresi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    SirketId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmanlar", x => x.DepartmanId);
                    table.ForeignKey(
                        name: "FK_Departmanlar_Sirketler_SirketId",
                        column: x => x.SirketId,
                        principalTable: "Sirketler",
                        principalColumn: "SirketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SirketYoneticileri",
                columns: table => new
                {
                    SirketYoneticisiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SirketId = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SirketYoneticileri", x => x.SirketYoneticisiId);
                    table.ForeignKey(
                        name: "FK_SirketYoneticileri_Sirketler_SirketId",
                        column: x => x.SirketId,
                        principalTable: "Sirketler",
                        principalColumn: "SirketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    YorumId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YorumBaslik = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    YorumIcerik = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false),
                    SirketId = table.Column<int>(type: "int", nullable: false),
                    OlusturulmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.YorumId);
                    table.ForeignKey(
                        name: "FK_Yorumlar_Sirketler_SirketId",
                        column: x => x.SirketId,
                        principalTable: "Sirketler",
                        principalColumn: "SirketId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personeller",
                columns: table => new
                {
                    PersonelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YillikIzinHakki = table.Column<int>(type: "int", nullable: false),
                    IseBaslama = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IstenAyrilma = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SirketId = table.Column<int>(type: "int", nullable: false),
                    DepartmanId = table.Column<int>(type: "int", nullable: false),
                    Ad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ResimUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personeller", x => x.PersonelId);
                    table.ForeignKey(
                        name: "FK_Personeller_Departmanlar_DepartmanId",
                        column: x => x.DepartmanId,
                        principalTable: "Departmanlar",
                        principalColumn: "DepartmanId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personeller_Sirketler_SirketId",
                        column: x => x.SirketId,
                        principalTable: "Sirketler",
                        principalColumn: "SirketId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Harcamalar",
                columns: table => new
                {
                    HarcamaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    HarcamaIsmi = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    HarcamaTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Harcamalar", x => x.HarcamaId);
                    table.ForeignKey(
                        name: "FK_Harcamalar_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Izinler",
                columns: table => new
                {
                    IzinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IzinTurId = table.Column<int>(type: "int", nullable: false),
                    IzinSuresi = table.Column<int>(type: "int", nullable: false),
                    ReddilmeNedeni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IzinIstemeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OnaylanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IzinBaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IzinBitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    SirketYoneticisiId = table.Column<int>(type: "int", nullable: false),
                    OnayDurumu = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izinler", x => x.IzinId);
                    table.ForeignKey(
                        name: "FK_Izinler_IzinTurleri_IzinTurId",
                        column: x => x.IzinTurId,
                        principalTable: "IzinTurleri",
                        principalColumn: "IzinTurId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Izinler_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Izinler_SirketYoneticileri_SirketYoneticisiId",
                        column: x => x.SirketYoneticisiId,
                        principalTable: "SirketYoneticileri",
                        principalColumn: "SirketYoneticisiId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MaasBilgileri",
                columns: table => new
                {
                    MaasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    VerilisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaasTutari = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaasBilgileri", x => x.MaasId);
                    table.ForeignKey(
                        name: "FK_MaasBilgileri_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Molalar",
                columns: table => new
                {
                    MolaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MolaAdi = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    OlusturulduguTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MolaSuresi = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Molalar", x => x.MolaId);
                    table.ForeignKey(
                        name: "FK_Molalar_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OzlukBelgeleri",
                columns: table => new
                {
                    OzlukBelgesiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    OzlukBelgesiAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OzlukBelgesiYolu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OlusturulmaZamani = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SirketYoneticisiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OzlukBelgeleri", x => x.OzlukBelgesiId);
                    table.ForeignKey(
                        name: "FK_OzlukBelgeleri_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OzlukBelgeleri_SirketYoneticileri_SirketYoneticisiId",
                        column: x => x.SirketYoneticisiId,
                        principalTable: "SirketYoneticileri",
                        principalColumn: "SirketYoneticisiId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Primler",
                columns: table => new
                {
                    PrimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimTuruId = table.Column<int>(type: "int", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    PrimMiktari = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrimVerilisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Primler", x => x.PrimId);
                    table.ForeignKey(
                        name: "FK_Primler_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Primler_PrimTurleri_PrimTuruId",
                        column: x => x.PrimTuruId,
                        principalTable: "PrimTurleri",
                        principalColumn: "PrimTuruId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vardiyalar",
                columns: table => new
                {
                    VardiyaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    VardiyaTuru = table.Column<int>(type: "int", nullable: false),
                    VardiyaBaslangicTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VardiyaBitisTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vardiyalar", x => x.VardiyaId);
                    table.ForeignKey(
                        name: "FK_Vardiyalar_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zimmetler",
                columns: table => new
                {
                    ZimmetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZimmetTuruId = table.Column<int>(type: "int", nullable: false),
                    ZimmetTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZimmetTeslimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeslimEdildiMi = table.Column<bool>(type: "bit", nullable: false),
                    PersonelId = table.Column<int>(type: "int", nullable: false),
                    Durumu = table.Column<int>(type: "int", nullable: false),
                    NotIcerik = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zimmetler", x => x.ZimmetId);
                    table.ForeignKey(
                        name: "FK_Zimmetler_Personeller_PersonelId",
                        column: x => x.PersonelId,
                        principalTable: "Personeller",
                        principalColumn: "PersonelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Zimmetler_ZimmetTurleri_ZimmetTuruId",
                        column: x => x.ZimmetTuruId,
                        principalTable: "ZimmetTurleri",
                        principalColumn: "ZimmetTuruId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departmanlar_SirketId",
                table: "Departmanlar",
                column: "SirketId");

            migrationBuilder.CreateIndex(
                name: "IX_Harcamalar_PersonelId",
                table: "Harcamalar",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_IzinTurId",
                table: "Izinler",
                column: "IzinTurId");

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_PersonelId",
                table: "Izinler",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Izinler_SirketYoneticisiId",
                table: "Izinler",
                column: "SirketYoneticisiId");

            migrationBuilder.CreateIndex(
                name: "IX_MaasBilgileri_PersonelId",
                table: "MaasBilgileri",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Molalar_PersonelId",
                table: "Molalar",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_OzlukBelgeleri_PersonelId",
                table: "OzlukBelgeleri",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_OzlukBelgeleri_SirketYoneticisiId",
                table: "OzlukBelgeleri",
                column: "SirketYoneticisiId");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_DepartmanId",
                table: "Personeller",
                column: "DepartmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Personeller_SirketId",
                table: "Personeller",
                column: "SirketId");

            migrationBuilder.CreateIndex(
                name: "IX_Primler_PersonelId",
                table: "Primler",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Primler_PrimTuruId",
                table: "Primler",
                column: "PrimTuruId");

            migrationBuilder.CreateIndex(
                name: "IX_SirketYoneticileri_SirketId",
                table: "SirketYoneticileri",
                column: "SirketId");

            migrationBuilder.CreateIndex(
                name: "IX_Vardiyalar_PersonelId",
                table: "Vardiyalar",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorumlar_SirketId",
                table: "Yorumlar",
                column: "SirketId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zimmetler_PersonelId",
                table: "Zimmetler",
                column: "PersonelId");

            migrationBuilder.CreateIndex(
                name: "IX_Zimmetler_ZimmetTuruId",
                table: "Zimmetler",
                column: "ZimmetTuruId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Harcamalar");

            migrationBuilder.DropTable(
                name: "Izinler");

            migrationBuilder.DropTable(
                name: "MaasBilgileri");

            migrationBuilder.DropTable(
                name: "Molalar");

            migrationBuilder.DropTable(
                name: "OzlukBelgeleri");

            migrationBuilder.DropTable(
                name: "Primler");

            migrationBuilder.DropTable(
                name: "SiteYoneticileri");

            migrationBuilder.DropTable(
                name: "Vardiyalar");

            migrationBuilder.DropTable(
                name: "Yorumlar");

            migrationBuilder.DropTable(
                name: "Zimmetler");

            migrationBuilder.DropTable(
                name: "IzinTurleri");

            migrationBuilder.DropTable(
                name: "SirketYoneticileri");

            migrationBuilder.DropTable(
                name: "PrimTurleri");

            migrationBuilder.DropTable(
                name: "Personeller");

            migrationBuilder.DropTable(
                name: "ZimmetTurleri");

            migrationBuilder.DropTable(
                name: "Departmanlar");

            migrationBuilder.DropTable(
                name: "Sirketler");
        }
    }
}
