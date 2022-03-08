using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class cuj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rezervacijes",
                columns: table => new
                {
                    RezervacijaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(nullable: false),
                    Rezervisano = table.Column<bool>(nullable: false),
                    AutomobilId = table.Column<int>(nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Rezervacijes_AutomobilId",
                table: "Rezervacijes",
                column: "AutomobilId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rezervacijes");
        }
    }
}
