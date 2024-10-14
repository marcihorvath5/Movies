using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Filmek.Migrations
{
    /// <inheritdoc />
    public partial class onemore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_CategoriesId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "CategoriesId",
                table: "Movies",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CategoriesId",
                table: "Movies",
                newName: "IX_Movies_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_CategoryId",
                table: "Movies",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Categories_CategoryId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Movies",
                newName: "CategoriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_CategoryId",
                table: "Movies",
                newName: "IX_Movies_CategoriesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Categories_CategoriesId",
                table: "Movies",
                column: "CategoriesId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
