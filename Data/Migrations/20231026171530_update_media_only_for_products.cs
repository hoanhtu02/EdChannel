using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdChannel.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_media_only_for_products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Media_AspNetUsers_ApplicationUserId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_Category_CategoryId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_ApplicationUserId",
                table: "Media");

            migrationBuilder.DropIndex(
                name: "IX_Media_CategoryId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Media");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Media");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<long>(
                name: "ApplicationUserId",
                table: "Media",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "Media",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Media_ApplicationUserId",
                table: "Media",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Media_CategoryId",
                table: "Media",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_AspNetUsers_ApplicationUserId",
                table: "Media",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Category_CategoryId",
                table: "Media",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }
    }
}
