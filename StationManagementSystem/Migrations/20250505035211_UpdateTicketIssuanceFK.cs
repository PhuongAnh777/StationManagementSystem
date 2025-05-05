using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTicketIssuanceFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TicketIssuances_ItineraryID",
                table: "TicketIssuances");

            migrationBuilder.CreateIndex(
                name: "IX_TicketIssuances_ItineraryID",
                table: "TicketIssuances",
                column: "ItineraryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TicketIssuances_ItineraryID",
                table: "TicketIssuances");

            migrationBuilder.CreateIndex(
                name: "IX_TicketIssuances_ItineraryID",
                table: "TicketIssuances",
                column: "ItineraryID",
                unique: true);
        }
    }
}
