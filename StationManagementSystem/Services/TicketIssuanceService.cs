using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationManagementSystem.DTO.TicketIssuance;
using StationManagementSystem.DTO.Vehicle;
using StationManagementSystem.Models;

namespace StationManagementSystem.Services
{
    public class TicketIssuanceService
    {
        private readonly StationContext _context;
        public TicketIssuanceService()
        {
            _context = new StationContext();
        }
        public async Task<IEnumerable<TicketIssuance>> GetAllTicketIssuancesAsync()
        {
            return await _context.TicketIssuances.ToListAsync();
        }
        public async Task<IEnumerable<Vehicle>> GetVehiclesDepartingInOneHourAsync()
        {
            var now = DateTime.Now;
            var oneHourLater = now.AddHours(1);

            var vehicles = _context.TicketIssuances
                .Where(ti => ti.EstimatedDepartureTime >= now && ti.EstimatedDepartureTime <= oneHourLater)
                .Select(ti => ti.Vehicle)
                .Distinct() // Nếu một xe có nhiều lần phát hành vé gần nhau thì tránh trùng
                .ToList();

            return vehicles;
        }
        public async Task<TicketIssuance> GetTicketIssuanceByIdAsync(Guid issuanceID)
        {
            return await _context.TicketIssuances
                .FirstOrDefaultAsync(v => v.IssuanceID == issuanceID);
        }
        public async Task<TicketIssuance> GetTicketIssuanceByVehicleIdAsync(Guid vehicleID)
        {
            return await _context.TicketIssuances
                .FirstOrDefaultAsync(ti => ti.VehicleID == vehicleID && ti.Status.ToLower() == "active");
        }
        public async Task<TicketIssuance> CreateTicketIssuancesAsync(TicketIssuanceCreateDto ticketIssuanceDto)
        {
            var ticketIssuance = new TicketIssuance
            {
                ItineraryID = ticketIssuanceDto.ItineraryID,
                CreatedAt = ticketIssuanceDto.CreatedAt,
                StartDate = ticketIssuanceDto.StartDate,
                EndDate = ticketIssuanceDto.EndDate,
                OperatingSchedule = ticketIssuanceDto.OperatingSchedule,
                MonthlyFrequency = ticketIssuanceDto.MonthlyFrequency,
                PaymentMethod = ticketIssuanceDto.PaymentMethod,
                ServiceFee = ticketIssuanceDto.ServiceFee,
                TicketSalesCommission = ticketIssuanceDto.TicketSalesCommission,
                SeatTicket = ticketIssuanceDto.SeatTicket,
                SleeperTicket = ticketIssuanceDto.SleeperTicket,
                Status = "Pending",
                Notes = ticketIssuanceDto.Notes,
                EstimatedDepartureTime = ticketIssuanceDto.EstimatedDepartureTime,
                EstimatedArrivalTime = ticketIssuanceDto.EstimatedArrivalTime,
                EmployeeID = ticketIssuanceDto.EmployeeID,
                VehicleID = ticketIssuanceDto.VehicleID,
            };
            await _context.TicketIssuances.AddAsync(ticketIssuance);


            await _context.SaveChangesAsync();
            return ticketIssuance;
        }
        //public async Task<Vehicle> UpdateVehicleAsync(Guid vehicleId, VehicleUpdateDto vehicleDto)
        //{
        //    if (vehicleDto == null)
        //        throw new ArgumentNullException(nameof(vehicleDto), "vehicle data is required.");

        //    var vehicle = await _context.Vehicles.FirstOrDefaultAsync(p => p.VehicleID == vehicleId);

        //    if (vehicle == null)
        //        throw new KeyNotFoundException($"Employee with ID {vehicleId} not found.");

        //    // Update product properties

        //    vehicle.InspectionExpiryDate = vehicleDto.InspectionExpiryDate;
        //    vehicle.InspectionStartDate = vehicleDto.InspectionStartDate;
        //    vehicle.ImpoundmentDate = vehicleDto.ImpoundmentDate;
        //    vehicle.ReleaseDate = vehicleDto.ReleaseDate;
        //    vehicle.Registration = vehicleDto.Registration;
        //    vehicle.Insurance = vehicleDto.Insurance;
        //    vehicle.LicensePlate = vehicleDto.LicensePlate;
        //    vehicle.ManufacturingYear = vehicleDto.ManufacturingYear;
        //    vehicle.SeatTicket = vehicleDto.SeatTicket;
        //    vehicle.SleeperTicket = vehicleDto.SleeperTicket;
        //    vehicle.VehicleType = vehicleDto.VehicleType;

        //    // Save changes to the database, this will automatically check the RowVersion
        //    await _context.SaveChangesAsync();

        //    return vehicle;

        //}
        //public async Task<Vehicle> UpdateVehicleStatusAsync(Guid vehicleId)
        //{

        //    var vehicle = await _context.Vehicles.FirstOrDefaultAsync(p => p.VehicleID == vehicleId);

        //    if (vehicle == null)
        //        throw new KeyNotFoundException($"Employee with ID {vehicleId} not found.");

        //    // Update product properties
        //    vehicle.IsDiscontinued = true;

        //    // Save changes to the database, this will automatically check the RowVersion
        //    await _context.SaveChangesAsync();

        //    return vehicle;

        //}
        //public async Task<bool> DeleteVehicleAsync(Guid id)
        //{
        //    var vehicle = await _context.Vehicles.FindAsync(id);
        //    if (vehicle == null)
        //    {
        //        return false;
        //    }

        //    _context.Vehicles.Remove(vehicle);
        //    await _context.SaveChangesAsync();

        //    return true;
        //}
    }
}
