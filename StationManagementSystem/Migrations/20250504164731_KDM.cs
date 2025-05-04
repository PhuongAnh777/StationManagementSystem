using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class KDM : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedArrivalTime",
                table: "TicketIssuances");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedArrivalTime",
                table: "TicketIssuances",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
