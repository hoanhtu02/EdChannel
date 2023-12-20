using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdChannel.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Media",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "MediaId",
                table: "Category",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_CategoryId",
                table: "Media",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Category_CategoryId",
                table: "Media",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_Category_CategoryId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_CategoryId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "MediaId",
                table: "Category");
        }
    }
}
