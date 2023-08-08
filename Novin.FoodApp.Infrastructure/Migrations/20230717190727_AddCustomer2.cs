using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Novin.FoodApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerPassword",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RestaurantAddress",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientUsername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClientPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientFullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_ApplicationUsers_ClientUsername",
                        column: x => x.ClientUsername,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Username");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ClientUsername",
                table: "Customers",
                column: "ClientUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropColumn(
                name: "OwnerPassword",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "RestaurantAddress",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "ApplicationUsers");
        }
    }
}
