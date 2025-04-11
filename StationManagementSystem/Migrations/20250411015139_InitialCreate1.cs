using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StationManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Department",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Registration",
                table: "Vehicles",
                type: "NVARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)");

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturingYear",
                table: "Vehicles",
                type: "INT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INT");

            migrationBuilder.AlterColumn<string>(
                name: "Insurance",
                table: "Vehicles",
                type: "NVARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InspectionStartDate",
                table: "Vehicles",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<DateTime>(
                name: "InspectionExpiryDate",
                table: "Vehicles",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Owners",
                type: "NVARCHAR(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IDCard",
                table: "Owners",
                type: "NVARCHAR(15)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(15)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "Owners",
                type: "NVARCHAR(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Employees",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AddColumn<bool>(
                name: "Gender",
                table: "Employees",
                type: "BIT",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "Registration",
                table: "Vehicles",
                type: "NVARCHAR(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ManufacturingYear",
                table: "Vehicles",
                type: "INT",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Insurance",
                table: "Vehicles",
                type: "NVARCHAR(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InspectionStartDate",
                table: "Vehicles",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InspectionExpiryDate",
                table: "Vehicles",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Owners",
                type: "NVARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)");

            migrationBuilder.AlterColumn<string>(
                name: "IDCard",
                table: "Owners",
                type: "NVARCHAR(15)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(15)");

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "Owners",
                type: "NVARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(100)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Employees",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Employees",
                type: "NVARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Employees",
                type: "NVARCHAR(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Salary",
                table: "Employees",
                type: "FLOAT",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
