using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class nova : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lokacijas",
                columns: table => new
                {
                    LokacijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Ime = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacijas", x => x.LokacijaId);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjacs",
                columns: table => new
                {
                    ProizvodjacId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Detalji = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjacs", x => x.ProizvodjacId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "TipAutomobilas",
                columns: table => new
                {
                    TipAutomobilaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipAutomobilas", x => x.TipAutomobilaId);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    ModelId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false),
                    NajamPoDanu = table.Column<string>(nullable: false),
                    ProizvodjacId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.ModelId);
                    table.ForeignKey(
                        name: "FK_Models_Proizvodjacs_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjacs",
                        principalColumn: "ProizvodjacId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Automobils",
                columns: table => new
                {
                    AutomobilId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tablice = table.Column<string>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    TipAutomobilaId = table.Column<int>(nullable: false),
                    LokacijaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobils", x => x.AutomobilId);
                    table.ForeignKey(
                        name: "FK_Automobils_Lokacijas_LokacijaId",
                        column: x => x.LokacijaId,
                        principalTable: "Lokacijas",
                        principalColumn: "LokacijaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Automobils_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
                        principalColumn: "ModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Automobils_TipAutomobilas_TipAutomobilaId",
                        column: x => x.TipAutomobilaId,
                        principalTable: "TipAutomobilas",
                        principalColumn: "TipAutomobilaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    RentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPocetka = table.Column<DateTime>(nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(nullable: false),
                    StatusId = table.Column<int>(nullable: true),
                    AutomobilId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.RentId);
                    table.ForeignKey(
                        name: "FK_Rents_Automobils_AutomobilId",
                        column: x => x.AutomobilId,
                        principalTable: "Automobils",
                        principalColumn: "AutomobilId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rents_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobils_LokacijaId",
                table: "Automobils",
                column: "LokacijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobils_ModelId",
                table: "Automobils",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobils_TipAutomobilaId",
                table: "Automobils",
                column: "TipAutomobilaId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ProizvodjacId",
                table: "Models",
                column: "ProizvodjacId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_AutomobilId",
                table: "Rents",
                column: "AutomobilId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_StatusId",
                table: "Rents",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Automobils");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Lokacijas");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "TipAutomobilas");

            migrationBuilder.DropTable(
                name: "Proizvodjacs");
        }
    }
}
