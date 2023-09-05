using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Novin.FoodApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VerificationCode",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Verifide",
                table: "ApplicationUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VerificationCode",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "Verifide",
                table: "ApplicationUsers");
        }
    }
}
