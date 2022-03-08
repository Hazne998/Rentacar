using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class user : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Rents",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rents_ApplicationUserId",
                table: "Rents",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_AspNetUsers_ApplicationUserId",
                table: "Rents",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rents_AspNetUsers_ApplicationUserId",
                table: "Rents");

            migrationBuilder.DropIndex(
                name: "IX_Rents_ApplicationUserId",
                table: "Rents");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Rents");
        }
    }
}
