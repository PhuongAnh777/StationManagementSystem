using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Model",
                table: "Vehicles");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Vehicles",
                type: "NVARCHAR(50)",
                nullable: false,
                defaultValue: "");
        }
    }
}
