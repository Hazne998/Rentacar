using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class AddCustomTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brends",
                columns: table => new
                {
                    BrendId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Opis = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brends", x => x.BrendId);
                });

            migrationBuilder.CreateTable(
                name: "TipAutomobilas",
                columns: table => new
                {
                    TipAutomobilaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipAutomobilas", x => x.TipAutomobilaId);
                });

            migrationBuilder.CreateTable(
                name: "Automobils",
                columns: table => new
                {
                    AutomobilId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    CijenaPoDanu = table.Column<double>(nullable: false),
                    BrendId = table.Column<int>(nullable: true),
                    TipAutomobilaId = table.Column<int>(nullable: true)
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
                    RentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumPocetka = table.Column<DateTime>(nullable: false),
                    DatumZavrsetka = table.Column<DateTime>(nullable: false),
                    Placeno = table.Column<bool>(nullable: false),
                    Naplaceno = table.Column<bool>(nullable: false),
                    Vraceno = table.Column<bool>(nullable: false),
                    AutomobilId = table.Column<int>(nullable: false)
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
                name: "Racuns",
                columns: table => new
                {
                    RentId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Trosak = table.Column<double>(nullable: false)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Racuns");

            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Automobils");

            migrationBuilder.DropTable(
                name: "Brends");

            migrationBuilder.DropTable(
                name: "TipAutomobilas");
        }
    }
}
