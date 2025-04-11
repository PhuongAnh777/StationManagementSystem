using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class IsDiscontinuedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDiscontinued",
                table: "Owners");

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscontinued",
                table: "Employees",
                type: "BIT",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDiscontinued",
                table: "Employees");

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscontinued",
                table: "Owners",
                type: "BIT",
                nullable: false,
                defaultValue: false);
        }
    }
}
