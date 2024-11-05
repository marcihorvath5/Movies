using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmek.Migrations
{
    /// <inheritdoc />
    public partial class seriedb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerieCategories_Categories_CategoryId",
                table: "SerieCategories");

            migrationBuilder.CreateTable(
                name: "Scategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scategories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_SerieCategories_Scategories_CategoryId",
                table: "SerieCategories",
                column: "CategoryId",
                principalTable: "Scategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerieCategories_Scategories_CategoryId",
                table: "SerieCategories");

            migrationBuilder.DropTable(
                name: "Scategories");

            migrationBuilder.AddForeignKey(
                name: "FK_SerieCategories_Categories_CategoryId",
                table: "SerieCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
