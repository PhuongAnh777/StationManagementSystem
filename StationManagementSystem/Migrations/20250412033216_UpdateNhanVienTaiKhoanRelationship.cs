using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNhanVienTaiKhoanRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDiscontinued",
                table: "TicketIssuances",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ItineraryID",
                table: "TicketIssuances",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscontinued",
                table: "Invoices",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscontinued",
                table: "DepartureOrders",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscontinued",
                table: "Accounts",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_TicketIssuances_ItineraryID",
                table: "TicketIssuances",
                column: "ItineraryID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketIssuances_Itineraries",
                table: "TicketIssuances",
                column: "ItineraryID",
                principalTable: "Itineraries",
                principalColumn: "ItineraryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketIssuances_Itineraries",
                table: "TicketIssuances");

            migrationBuilder.DropIndex(
                name: "IX_TicketIssuances_ItineraryID",
                table: "TicketIssuances");

            migrationBuilder.DropColumn(
                name: "IsDiscontinued",
                table: "TicketIssuances");

            migrationBuilder.DropColumn(
                name: "ItineraryID",
                table: "TicketIssuances");

            migrationBuilder.DropColumn(
                name: "IsDiscontinued",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "IsDiscontinued",
                table: "DepartureOrders");

            migrationBuilder.DropColumn(
                name: "IsDiscontinued",
                table: "Accounts");
        }
    }
}
