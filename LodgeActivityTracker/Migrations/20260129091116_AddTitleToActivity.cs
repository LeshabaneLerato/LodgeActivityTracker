using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LodgeActivityTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddTitleToActivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Activities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Activities");
        }
    }
}
