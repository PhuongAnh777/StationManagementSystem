using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace StationManagementSystem.Models
{
    public class StationContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public StationContext()
        {

        }
        public StationContext(DbContextOptions<StationContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-APUENFVC\\SQLEXPRESS;Database=Station;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true");
            }
        }
        public Microsoft.EntityFrameworkCore.DbSet<Account> Accounts { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<DepartureOrder> DepartureOrders { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Employee> Employees { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Invoice> Invoices { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Itinerary> Itineraries { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Owner> Owners { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Permission> Permissions { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Role> Roles { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<RolesPermission> RolesPermissions { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Route> Routes { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Ticket> Tickets { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<TicketIssuance> TicketIssuances { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Account
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username);
                entity.Property(e => e.Username).HasColumnType("NVARCHAR(50)").IsRequired();
                entity.Property(e => e.Password).HasColumnType("NVARCHAR(100)").IsRequired();
                entity.Property(e => e.Status).HasColumnType("NVARCHAR(25)").IsRequired();
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accounts_Roles");

                entity.HasOne(d => d.Employee)
                    .WithOne(p => p.Account)  // Use WithOne instead of WithMany to indicate one-to-one relationship
                    .HasForeignKey<Account>(d => d.EmployeeID)  // Foreign key is still EmployeeID
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Accounts_Employees");
            });

            // DepartureOrder
            modelBuilder.Entity<DepartureOrder>(entity =>
            {
                entity.HasKey(e => e.OrderID);
                entity.Property(e => e.OrderID).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.DepartureOrders).HasColumnType("NVARCHAR(50)").IsRequired();
                entity.Property(e => e.DepartureTime).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.Status).HasColumnType("NVARCHAR(20)").IsRequired();

                entity.HasOne(d => d.Invoice)
                    .WithOne(i => i.DepartureOrder)
                    .HasForeignKey<DepartureOrder>(d => d.InvoiceID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartureOrders_Invoices");

                entity.HasOne(d => d.TicketIssuance)
                    .WithOne(t => t.DepartureOrder)
                    .HasForeignKey<DepartureOrder>(d => d.IssuanceID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DepartureOrders_TicketIssuances");
            });

            // Employee
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeID);
                entity.Property(e => e.FullName).HasColumnType("NVARCHAR(50)").IsRequired();
                entity.Property(e => e.Phone).HasColumnType("NVARCHAR(10)").IsRequired();
                entity.Property(e => e.Address).HasColumnType("NVARCHAR(100)").IsRequired();
                entity.Property(e => e.Email).HasColumnType("NVARCHAR(100)").IsRequired();
                entity.Property(e => e.BirthDate).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.Department).HasColumnType("NVARCHAR(50)").IsRequired();
                entity.Property(e => e.Position).HasColumnType("NVARCHAR(50)").IsRequired();
                entity.Property(e => e.Salary).HasColumnType("FLOAT").IsRequired();
            });

            // Invoice
            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceID);
                entity.Property(e => e.InvoiceID).HasDefaultValueSql("NEWID()");
                entity.Property(e => e.InvoiceDate).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.PaymentStatus).HasColumnType("NVARCHAR(25)").IsRequired();
                entity.Property(e => e.Amount).HasColumnType("FLOAT").IsRequired();
                entity.Property(e => e.SeatTicket).HasColumnType("INT").IsRequired();
                entity.Property(e => e.SleeperTicket).HasColumnType("INT").IsRequired();
                entity.Property(e => e.OvernightParkingFee).HasColumnType("FLOAT").IsRequired();
                entity.Property(e => e.WaitingFee).HasColumnType("FLOAT").IsRequired();
                entity.Property(e => e.WashingFee).HasColumnType("FLOAT").IsRequired();
                entity.Property(e => e.FuelCost).HasColumnType("FLOAT").IsRequired();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.EmployeeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoices_Employees");
            });

            // Itinerary
            modelBuilder.Entity<Itinerary>(entity =>
            {
                entity.HasKey(e => e.ItineraryID);
                entity.Property(e => e.ItineraryName).HasColumnType("NVARCHAR(100)").IsRequired();
                entity.Property(e => e.Terminus).HasColumnType("NVARCHAR(20)").IsRequired();

                entity.HasOne(d => d.Route)
                    .WithMany(r => r.Itineraries)
                    .HasForeignKey(d => d.RouteID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Itineraries_Routes");
            });

            // Owner
            modelBuilder.Entity<Owner>(entity =>
            {
                entity.HasKey(e => e.OwnerID);
                entity.Property(e => e.Name).HasColumnType("NVARCHAR(100)").IsRequired();
                entity.Property(e => e.IDCard).HasColumnType("NVARCHAR(15)");
                entity.Property(e => e.Phone).HasColumnType("NVARCHAR(100)");
                entity.Property(e => e.Address).HasColumnType("NVARCHAR(100)");
                entity.Property(e => e.Email).HasColumnType("NVARCHAR(100)");
                entity.Property(e => e.IsDiscontinued).HasColumnType("BIT").IsRequired();
                entity.Property(e => e.Company).HasColumnType("NVARCHAR(100)");
                entity.Property(e => e.DrivingLicense).HasColumnType("NVARCHAR(100)");
            });

            // Permission
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.PermissionID);
                entity.Property(e => e.PermissionName).HasColumnType("NVARCHAR(50)").IsRequired();
                entity.Property(e => e.Description).HasColumnType("NVARCHAR(MAX)").IsRequired();
            });

            // Role
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleID);
                entity.Property(e => e.RoleName).HasColumnType("NVARCHAR(50)").IsRequired();
                entity.Property(e => e.Description).HasColumnType("NVARCHAR(MAX)").IsRequired();
            });

            // RolesPermission
            modelBuilder.Entity<RolesPermission>(entity =>
            {
                entity.HasKey(e => new { e.RoleID, e.PermissionID });

                entity.HasOne(d => d.Role)
                    .WithMany(r => r.RolesPermissions)
                    .HasForeignKey(d => d.RoleID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolesPermissions_Roles");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolesPermissions)
                    .HasForeignKey(d => d.PermissionID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RolesPermissions_Permissions");
            });

            // Route
            modelBuilder.Entity<Route>(entity =>
            {
                entity.HasKey(e => e.RouteID);
                entity.Property(e => e.DeparturePoint).HasColumnType("NVARCHAR(20)").IsRequired();
                entity.Property(e => e.ArrivalPoint).HasColumnType("NVARCHAR(20)").IsRequired();
                entity.Property(e => e.Distance).HasColumnType("FLOAT").IsRequired();
            });

            // Ticket
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(e => e.TicketID);
                entity.Property(e => e.Price).HasColumnType("FLOAT").IsRequired();
                entity.Property(e => e.SeatNumber).HasColumnType("NVARCHAR(15)").IsRequired();
                entity.Property(e => e.TicketType).HasColumnType("NVARCHAR(20)").IsRequired();
                entity.Property(e => e.Status).HasColumnType("NVARCHAR(20)").IsRequired();

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.EmployeeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_Employees");

                entity.HasOne(d => d.TicketIssuance)
                    .WithMany(t => t.Tickets)
                    .HasForeignKey(d => d.IssuanceID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tickets_TicketIssuances");
            });

            // TicketIssuance
            modelBuilder.Entity<TicketIssuance>(entity =>
            {
                entity.HasKey(e => e.IssuanceID);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                entity.Property(e => e.StartDate).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.EndDate).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.OperatingSchedule).HasColumnType("NVARCHAR(20)").IsRequired();
                entity.Property(e => e.MonthlyFrequency).HasColumnType("INT").IsRequired();
                entity.Property(e => e.PaymentMethod).HasColumnType("NVARCHAR(100)").IsRequired();
                entity.Property(e => e.ServiceFee).HasColumnType("FLOAT").IsRequired();
                entity.Property(e => e.TicketSalesCommission).HasColumnType("FLOAT").IsRequired();
                entity.Property(e => e.SeatTicket).HasColumnType("INT").IsRequired();
                entity.Property(e => e.SleeperTicket).HasColumnType("INT").IsRequired();
                entity.Property(e => e.Status).HasColumnType("NVARCHAR(20)").IsRequired();
                entity.Property(e => e.Notes).HasColumnType("NVARCHAR(MAX)").IsRequired();
                entity.Property(e => e.EstimatedDepartureTime).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.EstimatedArrivalTime).HasColumnType("datetime").IsRequired();

                entity.HasOne(d => d.Employee)
                    .WithMany(e => e.TicketIssuances)
                    .HasForeignKey(d => d.EmployeeID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketIssuances_Employees");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(v => v.TicketIssuances)
                    .HasForeignKey(d => d.VehicleID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketIssuances_Vehicles");

                entity.HasOne(d => d.Route)
                    .WithMany(r => r.TicketIssuances)
                    .HasForeignKey(d => d.RouteID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TicketIssuances_Routes");
            });

            // Vehicle
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.VehicleID);
                entity.Property(e => e.LicensePlate).HasColumnType("NVARCHAR(20)").IsRequired();
                entity.Property(e => e.VehicleType).HasColumnType("NVARCHAR(50)").IsRequired();
                entity.Property(e => e.SeatTicket).HasColumnType("INT").IsRequired();
                entity.Property(e => e.SleeperTicket).HasColumnType("INT").IsRequired();
                entity.Property(e => e.ManufacturingYear).HasColumnType("INT").IsRequired();
                entity.Property(e => e.Model).HasColumnType("NVARCHAR(50)").IsRequired();
                entity.Property(e => e.Registration).HasColumnType("NVARCHAR(100)").IsRequired();
                entity.Property(e => e.Insurance).HasColumnType("NVARCHAR(100)").IsRequired();
                entity.Property(e => e.InspectionStartDate).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.InspectionExpiryDate).HasColumnType("datetime").IsRequired();
                entity.Property(e => e.ImpoundmentDate).HasColumnType("datetime");
                entity.Property(e => e.ReleaseDate).HasColumnType("datetime");

                entity.HasOne(d => d.Owner)
                    .WithMany(o => o.Vehicles)
                    .HasForeignKey(d => d.OwnerID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehicles_Owners");
            });

        }

    }
}
