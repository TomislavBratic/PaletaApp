using Microsoft.EntityFrameworkCore.Migrations;

namespace PaletaApp.Migrations
{
    public partial class UpdatingForeingkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_People_PersonId",
                table: "Adresses");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Adresses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_People_PersonId",
                table: "Adresses",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_People_PersonId",
                table: "Adresses");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Adresses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_People_PersonId",
                table: "Adresses",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
