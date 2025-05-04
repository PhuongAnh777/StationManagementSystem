using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateItineraryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StopPoint",
                table: "StopPoint");

            migrationBuilder.RenameTable(
                name: "StopPoint",
                newName: "StopPoints");

            migrationBuilder.RenameIndex(
                name: "IX_StopPoint_ItineraryID",
                table: "StopPoints",
                newName: "IX_StopPoints_ItineraryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StopPoints",
                table: "StopPoints",
                column: "StopPointID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StopPoints",
                table: "StopPoints");

            migrationBuilder.RenameTable(
                name: "StopPoints",
                newName: "StopPoint");

            migrationBuilder.RenameIndex(
                name: "IX_StopPoints_ItineraryID",
                table: "StopPoint",
                newName: "IX_StopPoint_ItineraryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StopPoint",
                table: "StopPoint",
                column: "StopPointID");
        }
    }
}
