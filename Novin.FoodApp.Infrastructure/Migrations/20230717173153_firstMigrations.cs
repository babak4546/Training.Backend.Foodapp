using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Novin.FoodApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class firstMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUsers",
                columns: table => new
                {
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUsers", x => x.Username);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerUsername = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    ApproverUsername = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ApprovedTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurants_ApplicationUsers_ApproverUsername",
                        column: x => x.ApproverUsername,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Username");
                    table.ForeignKey(
                        name: "FK_Restaurants_ApplicationUsers_OwnerUsername",
                        column: x => x.OwnerUsername,
                        principalTable: "ApplicationUsers",
                        principalColumn: "Username",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_ApproverUsername",
                table: "Restaurants",
                column: "ApproverUsername");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurants_OwnerUsername",
                table: "Restaurants",
                column: "OwnerUsername");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.DropTable(
                name: "ApplicationUsers");
        }
    }
}
