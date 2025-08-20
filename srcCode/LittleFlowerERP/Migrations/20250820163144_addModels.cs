using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleFlowerERP.Migrations
{
    /// <inheritdoc />
    public partial class addModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Telefonnummer",
                table: "Kunden",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Artikel",
                columns: table => new
                {
                    ArtikelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LagerbestandID = table.Column<int>(type: "int", nullable: false),
                    Bezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verkaufspreis = table.Column<float>(type: "real", nullable: false),
                    Einkaufspreis = table.Column<float>(type: "real", nullable: false),
                    Einheit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikel", x => x.ArtikelID);
                });

            migrationBuilder.CreateTable(
                name: "Bestellung",
                columns: table => new
                {
                    BestellungID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LieferantID = table.Column<int>(type: "int", nullable: false),
                    Bestelldatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellung", x => x.BestellungID);
                    table.ForeignKey(
                        name: "FK_Bestellung_Lieferanten_LieferantID",
                        column: x => x.LieferantID,
                        principalTable: "Lieferanten",
                        principalColumn: "LieferantID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lagerort",
                columns: table => new
                {
                    LagerortID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bezeichnung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Standort = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lagerort", x => x.LagerortID);
                });

            migrationBuilder.CreateTable(
                name: "Rechnung",
                columns: table => new
                {
                    RechnungID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KundeID = table.Column<int>(type: "int", nullable: false),
                    Rechnungsdatum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Bezahlt = table.Column<bool>(type: "bit", nullable: false),
                    Gesamtpreis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Mahnstufe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rechnung", x => x.RechnungID);
                    table.ForeignKey(
                        name: "FK_Rechnung_Kunden_KundeID",
                        column: x => x.KundeID,
                        principalTable: "Kunden",
                        principalColumn: "KundeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bestellposition",
                columns: table => new
                {
                    BestellpositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BestellungID = table.Column<int>(type: "int", nullable: false),
                    ArtikelID = table.Column<int>(type: "int", nullable: false),
                    Menge = table.Column<int>(type: "int", nullable: false),
                    Preis = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bestellposition", x => x.BestellpositionID);
                    table.ForeignKey(
                        name: "FK_Bestellposition_Artikel_ArtikelID",
                        column: x => x.ArtikelID,
                        principalTable: "Artikel",
                        principalColumn: "ArtikelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bestellposition_Bestellung_BestellungID",
                        column: x => x.BestellungID,
                        principalTable: "Bestellung",
                        principalColumn: "BestellungID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lagerbestand",
                columns: table => new
                {
                    LagerbestandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LagerortID = table.Column<int>(type: "int", nullable: false),
                    ArtikelID = table.Column<int>(type: "int", nullable: false),
                    Menge = table.Column<int>(type: "int", nullable: false),
                    LetzteInventur = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lagerbestand", x => x.LagerbestandID);
                    table.ForeignKey(
                        name: "FK_Lagerbestand_Artikel_ArtikelID",
                        column: x => x.ArtikelID,
                        principalTable: "Artikel",
                        principalColumn: "ArtikelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lagerbestand_Lagerort_LagerortID",
                        column: x => x.LagerortID,
                        principalTable: "Lagerort",
                        principalColumn: "LagerortID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rechnungsposition",
                columns: table => new
                {
                    RechnungspositionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RechnungID = table.Column<int>(type: "int", nullable: false),
                    ArtikelID = table.Column<int>(type: "int", nullable: false),
                    Menge = table.Column<int>(type: "int", nullable: false),
                    Einzelpreis = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rechnungsposition", x => x.RechnungspositionID);
                    table.ForeignKey(
                        name: "FK_Rechnungsposition_Rechnung_RechnungID",
                        column: x => x.RechnungID,
                        principalTable: "Rechnung",
                        principalColumn: "RechnungID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtikelRechnungsposition",
                columns: table => new
                {
                    ArtikelID = table.Column<int>(type: "int", nullable: false),
                    RechnungspositionenRechnungspositionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtikelRechnungsposition", x => new { x.ArtikelID, x.RechnungspositionenRechnungspositionID });
                    table.ForeignKey(
                        name: "FK_ArtikelRechnungsposition_Artikel_ArtikelID",
                        column: x => x.ArtikelID,
                        principalTable: "Artikel",
                        principalColumn: "ArtikelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtikelRechnungsposition_Rechnungsposition_RechnungspositionenRechnungspositionID",
                        column: x => x.RechnungspositionenRechnungspositionID,
                        principalTable: "Rechnungsposition",
                        principalColumn: "RechnungspositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtikelRechnungsposition_RechnungspositionenRechnungspositionID",
                table: "ArtikelRechnungsposition",
                column: "RechnungspositionenRechnungspositionID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellposition_ArtikelID",
                table: "Bestellposition",
                column: "ArtikelID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellposition_BestellungID",
                table: "Bestellposition",
                column: "BestellungID");

            migrationBuilder.CreateIndex(
                name: "IX_Bestellung_LieferantID",
                table: "Bestellung",
                column: "LieferantID");

            migrationBuilder.CreateIndex(
                name: "IX_Lagerbestand_ArtikelID",
                table: "Lagerbestand",
                column: "ArtikelID");

            migrationBuilder.CreateIndex(
                name: "IX_Lagerbestand_LagerortID",
                table: "Lagerbestand",
                column: "LagerortID");

            migrationBuilder.CreateIndex(
                name: "IX_Rechnung_KundeID",
                table: "Rechnung",
                column: "KundeID");

            migrationBuilder.CreateIndex(
                name: "IX_Rechnungsposition_RechnungID",
                table: "Rechnungsposition",
                column: "RechnungID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtikelRechnungsposition");

            migrationBuilder.DropTable(
                name: "Bestellposition");

            migrationBuilder.DropTable(
                name: "Lagerbestand");

            migrationBuilder.DropTable(
                name: "Rechnungsposition");

            migrationBuilder.DropTable(
                name: "Bestellung");

            migrationBuilder.DropTable(
                name: "Artikel");

            migrationBuilder.DropTable(
                name: "Lagerort");

            migrationBuilder.DropTable(
                name: "Rechnung");

            migrationBuilder.DropColumn(
                name: "Telefonnummer",
                table: "Kunden");
        }
    }
}
