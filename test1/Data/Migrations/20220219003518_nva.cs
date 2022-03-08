using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class nva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Automobils");

            
            migrationBuilder.DropTable(
                name: "TipAutomobilas");

            migrationBuilder.DropTable(
                name: "Lokacijas");

            migrationBuilder.DropTable(
                name: "Models");


            migrationBuilder.DropTable(
                name: "Proizvodjacs");

            migrationBuilder.DropTable(
                name: "Statuses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brends",
                columns: table => new
                {
                    BrendId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brends", x => x.BrendId);
                });

            migrationBuilder.CreateTable(
                name: "TipAutomobilas",
                columns: table => new
                {
                    TipAutomobilaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipAutomobilas", x => x.TipAutomobilaId);
                });

            migrationBuilder.CreateTable(
                name: "Automobils",
                columns: table => new
                {
                    AutomobilId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrendId = table.Column<int>(type: "int", nullable: true),
                    CijenaPoDanu = table.Column<double>(type: "float", nullable: false),
                    Dostupnost = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tablice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipAutomobilaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobils", x => x.AutomobilId);
                    table.ForeignKey(
                        name: "FK_Automobils_Brends_BrendId",
                        column: x => x.BrendId,
                        principalTable: "Brends",
                        principalColumn: "BrendId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Automobils_TipAutomobilas_TipAutomobilaId",
                        column: x => x.TipAutomobilaId,
                        principalTable: "TipAutomobilas",
                        principalColumn: "TipAutomobilaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    RentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutomobilId = table.Column<int>(type: "int", nullable: false),
                    DatumPocetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Naplaceno = table.Column<bool>(type: "bit", nullable: false),
                    Placeno = table.Column<bool>(type: "bit", nullable: false),
                    Vraceno = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.RentId);
                    table.ForeignKey(
                        name: "FK_Rents_Automobils_AutomobilId",
                        column: x => x.AutomobilId,
                        principalTable: "Automobils",
                        principalColumn: "AutomobilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rezervacijes",
                columns: table => new
                {
                    RezervacijaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AutomobilId = table.Column<int>(type: "int", nullable: false),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rezervisano = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezervacijes", x => x.RezervacijaId);
                    table.ForeignKey(
                        name: "FK_Rezervacijes_Automobils_AutomobilId",
                        column: x => x.AutomobilId,
                        principalTable: "Automobils",
                        principalColumn: "AutomobilId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Racuns",
                columns: table => new
                {
                    RentId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Trosak = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racuns", x => x.RentId);
                    table.ForeignKey(
                        name: "FK_Racuns_Rents_RentId",
                        column: x => x.RentId,
                        principalTable: "Rents",
                        principalColumn: "RentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobils_BrendId",
                table: "Automobils",
                column: "BrendId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobils_TipAutomobilaId",
                table: "Automobils",
                column: "TipAutomobilaId");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_AutomobilId",
                table: "Rents",
                column: "AutomobilId");

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacijes_AutomobilId",
                table: "Rezervacijes",
                column: "AutomobilId");
        }
    }
}
