using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LittleFlowerERP.Migrations
{
    /// <inheritdoc />
    public partial class fixFKRechnungsposition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtikelRechnungsposition");

            migrationBuilder.CreateIndex(
                name: "IX_Rechnungsposition_ArtikelID",
                table: "Rechnungsposition",
                column: "ArtikelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Rechnungsposition_Artikel_ArtikelID",
                table: "Rechnungsposition",
                column: "ArtikelID",
                principalTable: "Artikel",
                principalColumn: "ArtikelID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rechnungsposition_Artikel_ArtikelID",
                table: "Rechnungsposition");

            migrationBuilder.DropIndex(
                name: "IX_Rechnungsposition_ArtikelID",
                table: "Rechnungsposition");

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
        }
    }
}
