using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inyection_dependency_example.Migrations
{
    /// <inheritdoc />
    public partial class PracticaDB3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoryDB",
                columns: table => new
                {
                    IdCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryDB", x => x.IdCategory);
                });

            migrationBuilder.CreateTable(
                name: "ProductDB",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true),
                    Worth = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Date_of_entry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FkCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDB", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_ProductDB_CategoryDB_FkCategory",
                        column: x => x.FkCategory,
                        principalTable: "CategoryDB",
                        principalColumn: "IdCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDB_FkCategory",
                table: "ProductDB",
                column: "FkCategory");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDB");

            migrationBuilder.DropTable(
                name: "CategoryDB");
        }
    }
}
