using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class CaiCach1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketIssuances_Routes",
                table: "TicketIssuances");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Employees",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_EmployeeID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SeatNumber",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "IsDiscontinued",
                table: "TicketIssuances");

            migrationBuilder.DropColumn(
                name: "IsDiscontinued",
                table: "DepartureOrders");

            migrationBuilder.AlterColumn<Guid>(
                name: "RouteID",
                table: "TicketIssuances",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "StopPoint",
                columns: table => new
                {
                    StopPointID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    StoppingTime = table.Column<int>(type: "INT", nullable: true),
                    StopOrder = table.Column<int>(type: "INT", nullable: false),
                    ItineraryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StopPoint", x => x.StopPointID);
                    table.ForeignKey(
                        name: "FK_StopPoints_Itineraries",
                        column: x => x.ItineraryID,
                        principalTable: "Itineraries",
                        principalColumn: "ItineraryID");
                });

            migrationBuilder.CreateTable(
                name: "TicketDetail",
                columns: table => new
                {
                    TicketDetailID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeatNumber = table.Column<string>(type: "NVARCHAR(15)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TicketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetail", x => x.TicketDetailID);
                    table.ForeignKey(
                        name: "FK_TicketDetails_Employees",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_TicketDetails_Tickets",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "TicketID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StopPoint_ItineraryID",
                table: "StopPoint",
                column: "ItineraryID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetail_EmployeeID",
                table: "TicketDetail",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetail_TicketID",
                table: "TicketDetail",
                column: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketIssuances_Routes_RouteID",
                table: "TicketIssuances",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "RouteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TicketIssuances_Routes_RouteID",
                table: "TicketIssuances");

            migrationBuilder.DropTable(
                name: "StopPoint");

            migrationBuilder.DropTable(
                name: "TicketDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeID",
                table: "Tickets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SeatNumber",
                table: "Tickets",
                type: "NVARCHAR(15)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Tickets",
                type: "NVARCHAR(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "RouteID",
                table: "TicketIssuances",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscontinued",
                table: "TicketIssuances",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscontinued",
                table: "DepartureOrders",
                type: "BIT",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EmployeeID",
                table: "Tickets",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_TicketIssuances_Routes",
                table: "TicketIssuances",
                column: "RouteID",
                principalTable: "Routes",
                principalColumn: "RouteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Employees",
                table: "Tickets",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID");
        }
    }
}
