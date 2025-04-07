using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Department = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Position = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Salary = table.Column<double>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    OwnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    IDCard = table.Column<string>(type: "NVARCHAR(15)", nullable: true),
                    Phone = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    Address = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    IsDiscontinued = table.Column<bool>(type: "BIT", nullable: false),
                    Company = table.Column<string>(type: "NVARCHAR(100)", nullable: true),
                    DrivingLicense = table.Column<string>(type: "NVARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.OwnerID);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleName = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    RouteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeparturePoint = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    ArrivalPoint = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    Distance = table.Column<double>(type: "FLOAT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.RouteID);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    InvoiceDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PaymentStatus = table.Column<string>(type: "NVARCHAR(25)", nullable: false),
                    Amount = table.Column<double>(type: "FLOAT", nullable: false),
                    SeatTicket = table.Column<int>(type: "INT", nullable: false),
                    SleeperTicket = table.Column<int>(type: "INT", nullable: false),
                    OvernightParkingFee = table.Column<double>(type: "FLOAT", nullable: false),
                    WaitingFee = table.Column<double>(type: "FLOAT", nullable: false),
                    WashingFee = table.Column<double>(type: "FLOAT", nullable: false),
                    FuelCost = table.Column<double>(type: "FLOAT", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceID);
                    table.ForeignKey(
                        name: "FK_Invoices_Employees",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LicensePlate = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    VehicleType = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    SeatTicket = table.Column<int>(type: "INT", nullable: false),
                    SleeperTicket = table.Column<int>(type: "INT", nullable: false),
                    ManufacturingYear = table.Column<int>(type: "INT", nullable: false),
                    Model = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Registration = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Insurance = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    InspectionStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    InspectionExpiryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ImpoundmentDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OwnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicles_Owners",
                        column: x => x.OwnerID,
                        principalTable: "Owners",
                        principalColumn: "OwnerID");
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Username = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    Password = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR(25)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Accounts_Employees",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_Accounts_Roles",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "RolesPermissions",
                columns: table => new
                {
                    RoleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesPermissions", x => new { x.RoleID, x.PermissionID });
                    table.ForeignKey(
                        name: "FK_RolesPermissions_Permissions",
                        column: x => x.PermissionID,
                        principalTable: "Permissions",
                        principalColumn: "PermissionID");
                    table.ForeignKey(
                        name: "FK_RolesPermissions_Roles",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Itineraries",
                columns: table => new
                {
                    ItineraryID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItineraryName = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    Terminus = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    RouteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itineraries", x => x.ItineraryID);
                    table.ForeignKey(
                        name: "FK_Itineraries_Routes",
                        column: x => x.RouteID,
                        principalTable: "Routes",
                        principalColumn: "RouteID");
                });

            migrationBuilder.CreateTable(
                name: "TicketIssuances",
                columns: table => new
                {
                    IssuanceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "GETDATE()"),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    OperatingSchedule = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    MonthlyFrequency = table.Column<int>(type: "INT", nullable: false),
                    PaymentMethod = table.Column<string>(type: "NVARCHAR(100)", nullable: false),
                    ServiceFee = table.Column<double>(type: "FLOAT", nullable: false),
                    TicketSalesCommission = table.Column<double>(type: "FLOAT", nullable: false),
                    SeatTicket = table.Column<int>(type: "INT", nullable: false),
                    SleeperTicket = table.Column<int>(type: "INT", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    Notes = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    EstimatedDepartureTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EstimatedArrivalTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VehicleID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RouteID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketIssuances", x => x.IssuanceID);
                    table.ForeignKey(
                        name: "FK_TicketIssuances_Employees",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_TicketIssuances_Routes",
                        column: x => x.RouteID,
                        principalTable: "Routes",
                        principalColumn: "RouteID");
                    table.ForeignKey(
                        name: "FK_TicketIssuances_Vehicles",
                        column: x => x.VehicleID,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleID");
                });

            migrationBuilder.CreateTable(
                name: "DepartureOrders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    DepartureOrders = table.Column<string>(type: "NVARCHAR(50)", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    InvoiceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssuanceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartureOrders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_DepartureOrders_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_DepartureOrders_Invoices",
                        column: x => x.InvoiceID,
                        principalTable: "Invoices",
                        principalColumn: "InvoiceID");
                    table.ForeignKey(
                        name: "FK_DepartureOrders_TicketIssuances",
                        column: x => x.IssuanceID,
                        principalTable: "TicketIssuances",
                        principalColumn: "IssuanceID");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<double>(type: "FLOAT", nullable: false),
                    SeatNumber = table.Column<string>(type: "NVARCHAR(15)", nullable: false),
                    TicketType = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    Status = table.Column<string>(type: "NVARCHAR(20)", nullable: false),
                    EmployeeID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IssuanceID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_Employees",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID");
                    table.ForeignKey(
                        name: "FK_Tickets_TicketIssuances",
                        column: x => x.IssuanceID,
                        principalTable: "TicketIssuances",
                        principalColumn: "IssuanceID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_EmployeeID",
                table: "Accounts",
                column: "EmployeeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_RoleID",
                table: "Accounts",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartureOrders_EmployeeID",
                table: "DepartureOrders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_DepartureOrders_InvoiceID",
                table: "DepartureOrders",
                column: "InvoiceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DepartureOrders_IssuanceID",
                table: "DepartureOrders",
                column: "IssuanceID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_EmployeeID",
                table: "Invoices",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Itineraries_RouteID",
                table: "Itineraries",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermissions_PermissionID",
                table: "RolesPermissions",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketIssuances_EmployeeID",
                table: "TicketIssuances",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketIssuances_RouteID",
                table: "TicketIssuances",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_TicketIssuances_VehicleID",
                table: "TicketIssuances",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_EmployeeID",
                table: "Tickets",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IssuanceID",
                table: "Tickets",
                column: "IssuanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_OwnerID",
                table: "Vehicles",
                column: "OwnerID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "DepartureOrders");

            migrationBuilder.DropTable(
                name: "Itineraries");

            migrationBuilder.DropTable(
                name: "RolesPermissions");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "TicketIssuances");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Owners");
        }
    }
}
