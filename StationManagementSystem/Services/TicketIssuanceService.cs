using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationManagementSystem.DTO.Ticket;
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
                .FirstOrDefaultAsync(ti => ti.VehicleID == vehicleID && ti.Status.ToLower() == "pending");
        }
        public async Task<IEnumerable<Vehicle>> GetVehiclesCheckAsync()
        {
            var now = DateTime.Now;
            var today = now.Date;
            var tomorrow = today.AddDays(1);
            var nowTime = now.TimeOfDay;

            var vehicles = await _context.TicketIssuances
                .Where(ti =>
                    ti.Status.ToLower() == "pending" &&
                    ti.CreatedAt.Date >= today &&
                    ti.CreatedAt.Date < tomorrow &&
                    ti.EstimatedDepartureTime.TimeOfDay > nowTime)
                .Select(ti => ti.Vehicle)
                .Distinct()
                .ToListAsync();

            return vehicles;
        }
        public async Task<IEnumerable<Vehicle>> GetCheckedVehiclesAsync()
        {
            var now = DateTime.Now;
            var oneHourLater = now.AddHours(1);
            var today = now.Date;
            var tomorrow = today.AddDays(1);

            var vehicles = await _context.TicketIssuances
                .Where(ti =>
                    ti.CreatedAt >= today && ti.CreatedAt < tomorrow && // chỉ trong ngày hôm nay
                    (
                        ti.Status.ToLower() == "checked" ||
                        (oneHourLater > now
                            ? (ti.EstimatedDepartureTime >= now && ti.EstimatedDepartureTime <= oneHourLater)
                            : (ti.EstimatedDepartureTime >= now || ti.EstimatedDepartureTime <= oneHourLater))
                    ))
                .Select(ti => ti.Vehicle)
                .Distinct()
                .ToListAsync();

            return vehicles;
        }
        public async Task<List<TicketDisplayItem>> GetCheckedSellTicketVehiclesAsync(Guid itineraryId)
        {
            var now = DateTime.Now;
            var oneHourLater = now.AddHours(1);
            var today = now.Date;
            var tomorrow = today.AddDays(1);

            var ticketIssuances = await _context.TicketIssuances
                .Include(ti => ti.Vehicle)
                    .ThenInclude(v => v.Owner)
                .Include(ti => ti.Tickets)
                .Where(ti =>
                    ti.CreatedAt >= today && ti.CreatedAt < tomorrow &&
                    ti.ItineraryID == itineraryId &&
                    (
                        ti.Status.ToLower() == "checked" ||
                        (oneHourLater > now
                            ? (ti.EstimatedDepartureTime >= now && ti.EstimatedDepartureTime <= oneHourLater)
                            : (ti.EstimatedDepartureTime >= now || ti.EstimatedDepartureTime <= oneHourLater))
                    ))
                .OrderBy(ti => ti.EstimatedDepartureTime)
                .Select(ti => new TicketDisplayItem
                {
                    DepartureTime = ti.EstimatedDepartureTime,
                    RemainingSeats = ti.Tickets.Sum(t => t.Amount) - ti.Tickets.Sum(t => t.TicketDetails.Count), // Tính số ghế còn lại
                    TotalSeats = ti.Tickets.Sum(t => t.Amount),
                    LicensePlate = ti.Vehicle.LicensePlate,
                    CompanyName = ti.Vehicle.Owner.Company,
                })
                .ToListAsync();

            return ticketIssuances;
        }


        //public async Task<IEnumerable<Vehicle>> GetVehiclesWithTicketCreatedTodayAsync()
        //{
        //    var today = DateTime.Today;
        //    var tomorrow = today.AddDays(1);

        //    var vehicles = await _context.TicketIssuances
        //        .Where(ti => ti.CreatedAt >= today && ti.CreatedAt < tomorrow)
        //        .Select(ti => ti.Vehicle)
        //        .Distinct()
        //        .ToListAsync();

        //    return vehicles;
        //}
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
        public async Task<TicketIssuance> UpdateTicketIssuancesStatusAsync(Guid issuancesId)
        {

            var ticketIssuance = await _context.TicketIssuances.FirstOrDefaultAsync(p => p.IssuanceID == issuancesId);

            if (ticketIssuance == null)
                throw new KeyNotFoundException($"Ticket inssuances with ID {issuancesId} not found.");

            // Update product properties
            ticketIssuance.Status = "Checked";

            // Save changes to the database, this will automatically check the RowVersion
            await _context.SaveChangesAsync();

            return ticketIssuance;

        }

        public async Task<bool> DeleteTicketIssuancesAsync(Guid id)
        {
            var ticketIssuances = await _context.TicketIssuances.FindAsync(id);
            if (ticketIssuances == null)
            {
                return false;
            }

            _context.TicketIssuances.Remove(ticketIssuances);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
