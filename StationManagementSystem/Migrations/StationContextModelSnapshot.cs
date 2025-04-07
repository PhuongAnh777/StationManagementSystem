﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StationManagementSystem.Models;

#nullable disable

namespace StationManagementSystem.Migrations
{
    [DbContext(typeof(StationContext))]
    partial class StationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StationManagementSystem.Models.Account", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("EmployeeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(25)");

                    b.HasKey("Username");

                    b.HasIndex("EmployeeID")
                        .IsUnique();

                    b.HasIndex("RoleID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("StationManagementSystem.Models.DepartureOrder", b =>
                {
                    b.Property<Guid>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("DepartureOrders")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("EmployeeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("InvoiceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IssuanceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.HasKey("OrderID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("InvoiceID")
                        .IsUnique();

                    b.HasIndex("IssuanceID")
                        .IsUnique();

                    b.ToTable("DepartureOrders");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Employee", b =>
                {
                    b.Property<Guid>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(10)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<double>("Salary")
                        .HasColumnType("FLOAT");

                    b.HasKey("EmployeeID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Invoice", b =>
                {
                    b.Property<Guid>("InvoiceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<double>("Amount")
                        .HasColumnType("FLOAT");

                    b.Property<Guid>("EmployeeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("FuelCost")
                        .HasColumnType("FLOAT");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime");

                    b.Property<double>("OvernightParkingFee")
                        .HasColumnType("FLOAT");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(25)");

                    b.Property<int>("SeatTicket")
                        .HasColumnType("INT");

                    b.Property<int>("SleeperTicket")
                        .HasColumnType("INT");

                    b.Property<double>("WaitingFee")
                        .HasColumnType("FLOAT");

                    b.Property<double>("WashingFee")
                        .HasColumnType("FLOAT");

                    b.HasKey("InvoiceID");

                    b.HasIndex("EmployeeID");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Itinerary", b =>
                {
                    b.Property<Guid>("ItineraryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ItineraryName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<Guid>("RouteID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Terminus")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.HasKey("ItineraryID");

                    b.HasIndex("RouteID");

                    b.ToTable("Itineraries");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Owner", b =>
                {
                    b.Property<Guid>("OwnerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Company")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("DrivingLicense")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Email")
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("IDCard")
                        .HasColumnType("NVARCHAR(15)");

                    b.Property<bool>("IsDiscontinued")
                        .HasColumnType("BIT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("Phone")
                        .HasColumnType("NVARCHAR(100)");

                    b.HasKey("OwnerID");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Permission", b =>
                {
                    b.Property<Guid>("PermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("PermissionName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("PermissionID");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Role", b =>
                {
                    b.Property<Guid>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("StationManagementSystem.Models.RolesPermission", b =>
                {
                    b.Property<Guid>("RoleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PermissionID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleID", "PermissionID");

                    b.HasIndex("PermissionID");

                    b.ToTable("RolesPermissions");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Route", b =>
                {
                    b.Property<Guid>("RouteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ArrivalPoint")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("DeparturePoint")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<double>("Distance")
                        .HasColumnType("FLOAT");

                    b.HasKey("RouteID");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Ticket", b =>
                {
                    b.Property<Guid>("TicketID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IssuanceID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("FLOAT");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(15)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("TicketType")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.HasKey("TicketID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("IssuanceID");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("StationManagementSystem.Models.TicketIssuance", b =>
                {
                    b.Property<Guid>("IssuanceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("EmployeeID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EstimatedArrivalTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("EstimatedDepartureTime")
                        .HasColumnType("datetime");

                    b.Property<int>("MonthlyFrequency")
                        .HasColumnType("INT");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(MAX)");

                    b.Property<string>("OperatingSchedule")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<Guid>("RouteID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SeatTicket")
                        .HasColumnType("INT");

                    b.Property<double>("ServiceFee")
                        .HasColumnType("FLOAT");

                    b.Property<int>("SleeperTicket")
                        .HasColumnType("INT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<double>("TicketSalesCommission")
                        .HasColumnType("FLOAT");

                    b.Property<Guid>("VehicleID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("IssuanceID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("RouteID");

                    b.HasIndex("VehicleID");

                    b.ToTable("TicketIssuances");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Vehicle", b =>
                {
                    b.Property<Guid>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ImpoundmentDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("InspectionExpiryDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("InspectionStartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Insurance")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<string>("LicensePlate")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<int>("ManufacturingYear")
                        .HasColumnType("INT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<Guid>("OwnerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Registration")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(100)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime");

                    b.Property<int>("SeatTicket")
                        .HasColumnType("INT");

                    b.Property<int>("SleeperTicket")
                        .HasColumnType("INT");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("VehicleID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Account", b =>
                {
                    b.HasOne("StationManagementSystem.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("StationManagementSystem.Models.Account", "EmployeeID")
                        .IsRequired()
                        .HasConstraintName("FK_Accounts_Employees");

                    b.HasOne("StationManagementSystem.Models.Role", "Role")
                        .WithMany("Accounts")
                        .HasForeignKey("RoleID")
                        .IsRequired()
                        .HasConstraintName("FK_Accounts_Roles");

                    b.Navigation("Employee");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("StationManagementSystem.Models.DepartureOrder", b =>
                {
                    b.HasOne("StationManagementSystem.Models.Employee", null)
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeID");

                    b.HasOne("StationManagementSystem.Models.Invoice", "Invoice")
                        .WithOne("DepartureOrder")
                        .HasForeignKey("StationManagementSystem.Models.DepartureOrder", "InvoiceID")
                        .IsRequired()
                        .HasConstraintName("FK_DepartureOrders_Invoices");

                    b.HasOne("StationManagementSystem.Models.TicketIssuance", "TicketIssuance")
                        .WithOne("DepartureOrder")
                        .HasForeignKey("StationManagementSystem.Models.DepartureOrder", "IssuanceID")
                        .IsRequired()
                        .HasConstraintName("FK_DepartureOrders_TicketIssuances");

                    b.Navigation("Invoice");

                    b.Navigation("TicketIssuance");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Invoice", b =>
                {
                    b.HasOne("StationManagementSystem.Models.Employee", "Employee")
                        .WithMany("Invoices")
                        .HasForeignKey("EmployeeID")
                        .IsRequired()
                        .HasConstraintName("FK_Invoices_Employees");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Itinerary", b =>
                {
                    b.HasOne("StationManagementSystem.Models.Route", "Route")
                        .WithMany("Itineraries")
                        .HasForeignKey("RouteID")
                        .IsRequired()
                        .HasConstraintName("FK_Itineraries_Routes");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("StationManagementSystem.Models.RolesPermission", b =>
                {
                    b.HasOne("StationManagementSystem.Models.Permission", "Permission")
                        .WithMany("RolesPermissions")
                        .HasForeignKey("PermissionID")
                        .IsRequired()
                        .HasConstraintName("FK_RolesPermissions_Permissions");

                    b.HasOne("StationManagementSystem.Models.Role", "Role")
                        .WithMany("RolesPermissions")
                        .HasForeignKey("RoleID")
                        .IsRequired()
                        .HasConstraintName("FK_RolesPermissions_Roles");

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Ticket", b =>
                {
                    b.HasOne("StationManagementSystem.Models.Employee", "Employee")
                        .WithMany("Tickets")
                        .HasForeignKey("EmployeeID")
                        .IsRequired()
                        .HasConstraintName("FK_Tickets_Employees");

                    b.HasOne("StationManagementSystem.Models.TicketIssuance", "TicketIssuance")
                        .WithMany("Tickets")
                        .HasForeignKey("IssuanceID")
                        .IsRequired()
                        .HasConstraintName("FK_Tickets_TicketIssuances");

                    b.Navigation("Employee");

                    b.Navigation("TicketIssuance");
                });

            modelBuilder.Entity("StationManagementSystem.Models.TicketIssuance", b =>
                {
                    b.HasOne("StationManagementSystem.Models.Employee", "Employee")
                        .WithMany("TicketIssuances")
                        .HasForeignKey("EmployeeID")
                        .IsRequired()
                        .HasConstraintName("FK_TicketIssuances_Employees");

                    b.HasOne("StationManagementSystem.Models.Route", "Route")
                        .WithMany("TicketIssuances")
                        .HasForeignKey("RouteID")
                        .IsRequired()
                        .HasConstraintName("FK_TicketIssuances_Routes");

                    b.HasOne("StationManagementSystem.Models.Vehicle", "Vehicle")
                        .WithMany("TicketIssuances")
                        .HasForeignKey("VehicleID")
                        .IsRequired()
                        .HasConstraintName("FK_TicketIssuances_Vehicles");

                    b.Navigation("Employee");

                    b.Navigation("Route");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Vehicle", b =>
                {
                    b.HasOne("StationManagementSystem.Models.Owner", "Owner")
                        .WithMany("Vehicles")
                        .HasForeignKey("OwnerID")
                        .IsRequired()
                        .HasConstraintName("FK_Vehicles_Owners");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Employee", b =>
                {
                    b.Navigation("Account")
                        .IsRequired();

                    b.Navigation("Invoices");

                    b.Navigation("Orders");

                    b.Navigation("TicketIssuances");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Invoice", b =>
                {
                    b.Navigation("DepartureOrder")
                        .IsRequired();
                });

            modelBuilder.Entity("StationManagementSystem.Models.Owner", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Permission", b =>
                {
                    b.Navigation("RolesPermissions");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Role", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("RolesPermissions");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Route", b =>
                {
                    b.Navigation("Itineraries");

                    b.Navigation("TicketIssuances");
                });

            modelBuilder.Entity("StationManagementSystem.Models.TicketIssuance", b =>
                {
                    b.Navigation("DepartureOrder")
                        .IsRequired();

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("StationManagementSystem.Models.Vehicle", b =>
                {
                    b.Navigation("TicketIssuances");
                });
#pragma warning restore 612, 618
        }
    }
}
