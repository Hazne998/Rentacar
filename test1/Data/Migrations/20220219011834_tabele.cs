using Microsoft.EntityFrameworkCore.Migrations;

namespace RentaCar.Data.Migrations
{
    public partial class tabele : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobils_Lokacijas_LokacijaId",
                table: "Automobils");

            migrationBuilder.DropForeignKey(
                name: "FK_Automobils_Models_ModelId",
                table: "Automobils");

            migrationBuilder.DropForeignKey(
                name: "FK_Automobils_TipAutomobilas_TipAutomobilaId",
                table: "Automobils");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Proizvodjacs_ProizvodjacId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Automobils_AutomobilId",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Statuses_StatusId",
                table: "Rents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipAutomobilas",
                table: "TipAutomobilas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proizvodjacs",
                table: "Proizvodjacs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lokacijas",
                table: "Lokacijas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Automobils",
                table: "Automobils");

            migrationBuilder.DropColumn(
                name: "TipAutomobilaId",
                table: "TipAutomobilas");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "ProizvodjacId",
                table: "Proizvodjacs");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "LokacijaId",
                table: "Lokacijas");

            migrationBuilder.DropColumn(
                name: "AutomobilId",
                table: "Automobils");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TipAutomobilas",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Statuses",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Rents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AutomobilId",
                table: "Rents",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Proizvodjacs",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Models",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Lokacijas",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Automobils",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipAutomobilas",
                table: "TipAutomobilas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proizvodjacs",
                table: "Proizvodjacs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lokacijas",
                table: "Lokacijas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Automobils",
                table: "Automobils",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Automobils_Lokacijas_LokacijaId",
                table: "Automobils",
                column: "LokacijaId",
                principalTable: "Lokacijas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Automobils_Models_ModelId",
                table: "Automobils",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Automobils_TipAutomobilas_TipAutomobilaId",
                table: "Automobils",
                column: "TipAutomobilaId",
                principalTable: "TipAutomobilas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Proizvodjacs_ProizvodjacId",
                table: "Models",
                column: "ProizvodjacId",
                principalTable: "Proizvodjacs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Automobils_AutomobilId",
                table: "Rents",
                column: "AutomobilId",
                principalTable: "Automobils",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Statuses_StatusId",
                table: "Rents",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Automobils_Lokacijas_LokacijaId",
                table: "Automobils");

            migrationBuilder.DropForeignKey(
                name: "FK_Automobils_Models_ModelId",
                table: "Automobils");

            migrationBuilder.DropForeignKey(
                name: "FK_Automobils_TipAutomobilas_TipAutomobilaId",
                table: "Automobils");

            migrationBuilder.DropForeignKey(
                name: "FK_Models_Proizvodjacs_ProizvodjacId",
                table: "Models");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Automobils_AutomobilId",
                table: "Rents");

            migrationBuilder.DropForeignKey(
                name: "FK_Rents_Statuses_StatusId",
                table: "Rents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TipAutomobilas",
                table: "TipAutomobilas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proizvodjacs",
                table: "Proizvodjacs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lokacijas",
                table: "Lokacijas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Automobils",
                table: "Automobils");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TipAutomobilas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Proizvodjacs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Models");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Lokacijas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Automobils");

            migrationBuilder.AddColumn<int>(
                name: "TipAutomobilaId",
                table: "TipAutomobilas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "StatusId",
                table: "Rents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AutomobilId",
                table: "Rents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProizvodjacId",
                table: "Proizvodjacs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Models",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LokacijaId",
                table: "Lokacijas",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "AutomobilId",
                table: "Automobils",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TipAutomobilas",
                table: "TipAutomobilas",
                column: "TipAutomobilaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proizvodjacs",
                table: "Proizvodjacs",
                column: "ProizvodjacId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "ModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lokacijas",
                table: "Lokacijas",
                column: "LokacijaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Automobils",
                table: "Automobils",
                column: "AutomobilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Automobils_Lokacijas_LokacijaId",
                table: "Automobils",
                column: "LokacijaId",
                principalTable: "Lokacijas",
                principalColumn: "LokacijaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Automobils_Models_ModelId",
                table: "Automobils",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "ModelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Automobils_TipAutomobilas_TipAutomobilaId",
                table: "Automobils",
                column: "TipAutomobilaId",
                principalTable: "TipAutomobilas",
                principalColumn: "TipAutomobilaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Models_Proizvodjacs_ProizvodjacId",
                table: "Models",
                column: "ProizvodjacId",
                principalTable: "Proizvodjacs",
                principalColumn: "ProizvodjacId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Automobils_AutomobilId",
                table: "Rents",
                column: "AutomobilId",
                principalTable: "Automobils",
                principalColumn: "AutomobilId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rents_Statuses_StatusId",
                table: "Rents",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "StatusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
