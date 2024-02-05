using Microsoft.EntityFrameworkCore.Migrations;

namespace BanakDataAccess.Migrations
{
    public partial class ChangeStatusToBoolValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Blog",
                newName: "status");

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "Blog",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "Blog",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Blog",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(bool),
                oldMaxLength: 50);
        }
    }
}
