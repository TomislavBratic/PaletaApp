using Microsoft.EntityFrameworkCore.Migrations;

namespace PaletaApp.Migrations
{
    public partial class AddForeignKeyinemailandaddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_People_PersonId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_People_PersonId",
                table: "Emails");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Emails",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Adresses",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_People_PersonId",
                table: "Adresses",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_People_PersonId",
                table: "Emails",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_People_PersonId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Emails_People_PersonId",
                table: "Emails");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Emails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Adresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_People_PersonId",
                table: "Adresses",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_People_PersonId",
                table: "Emails",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
