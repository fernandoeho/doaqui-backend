using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoeAqui.Infrastructure.Migrations
{
    public partial class AddProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "integer", maxLength: 255, nullable: false),
                    Size = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Freight = table.Column<int>(nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(max)", nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserId",
                table: "Products",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
