using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EdChannel.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_blog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Blog");
        }
    }
}
