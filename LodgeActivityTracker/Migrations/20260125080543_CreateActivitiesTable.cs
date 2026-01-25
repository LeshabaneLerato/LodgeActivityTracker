using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LodgeActivityTracker.Migrations
{
    /// <inheritdoc />
    public partial class CreateActivitiesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivityDate",
                table: "Activities",
                newName: "Date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Activities",
                newName: "ActivityDate");
        }
    }
}
