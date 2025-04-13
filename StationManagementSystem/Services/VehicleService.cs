using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationManagementSystem.DTO.Vehicle;
using StationManagementSystem.Models;

namespace StationManagementSystem.Services
{
    public class VehicleService
    {
        private readonly StationContext _context;
        public VehicleService()
        {
            _context = new StationContext();
        }
        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }
        public async Task<IEnumerable<Vehicle>> GetActiveVehiclesAsync()
        {
            return await _context.Vehicles
                .Where(v => v.IsDiscontinued == false) 
                .ToListAsync();
        }
        public async Task<Vehicle> GetVehicleByIdAsync(Guid vehicleId)
        {
            return await _context.Vehicles
                .FirstOrDefaultAsync(v => v.VehicleID == vehicleId);
        }
        public async Task<Vehicle> CreateVehicleAsync(VehicleCreateDto vehicleDto)
        {
            var vehicle = new Vehicle
            {
                LicensePlate = vehicleDto.LicensePlate,
                VehicleType = vehicleDto.VehicleType,
                SeatTicket = vehicleDto.SeatTicket,
                SleeperTicket = vehicleDto.SleeperTicket,
                ManufacturingYear = vehicleDto.ManufacturingYear,
                Registration = vehicleDto.Registration,
                Insurance = vehicleDto.Insurance,
                InspectionStartDate = vehicleDto.InspectionStartDate,
                InspectionExpiryDate = vehicleDto.InspectionExpiryDate,
                ImpoundmentDate = vehicleDto.ImpoundmentDate,
                ReleaseDate = vehicleDto.ReleaseDate,
                IsDiscontinued = false, // Mặc định là false
                OwnerID = vehicleDto.OwnerID
            };
            await _context.Vehicles.AddAsync(vehicle);


            await _context.SaveChangesAsync();
            return vehicle;
        }
        public async Task<Vehicle> UpdateVehicleAsync(Guid vehicleId, VehicleUpdateDto vehicleDto)
        {
            if (vehicleDto == null)
                throw new ArgumentNullException(nameof(vehicleDto), "vehicle data is required.");

            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(p => p.VehicleID == vehicleId);

            if (vehicle == null)
                throw new KeyNotFoundException($"Employee with ID {vehicleId} not found.");

            // Update product properties

            vehicle.InspectionExpiryDate = vehicleDto.InspectionExpiryDate;
            vehicle.InspectionStartDate = vehicleDto.InspectionStartDate;
            vehicle.ImpoundmentDate = vehicleDto.ImpoundmentDate;
            vehicle.ReleaseDate = vehicleDto.ReleaseDate;
            vehicle.Registration = vehicleDto.Registration;
            vehicle.Insurance = vehicleDto.Insurance;
            vehicle.LicensePlate = vehicleDto.LicensePlate;
            vehicle.ManufacturingYear = vehicleDto.ManufacturingYear;
            vehicle.SeatTicket = vehicleDto.SeatTicket;
            vehicle.SleeperTicket = vehicleDto.SleeperTicket;
            vehicle.VehicleType = vehicleDto.VehicleType;

            // Save changes to the database, this will automatically check the RowVersion
            await _context.SaveChangesAsync();

            return vehicle;

        }
        public async Task<Vehicle> UpdateVehicleStatusAsync(Guid vehicleId)
        {

            var vehicle = await _context.Vehicles.FirstOrDefaultAsync(p => p.VehicleID == vehicleId);

            if (vehicle == null)
                throw new KeyNotFoundException($"Employee with ID {vehicleId} not found.");

            // Update product properties
            vehicle.IsDiscontinued = true;
            
            // Save changes to the database, this will automatically check the RowVersion
            await _context.SaveChangesAsync();

            return vehicle;

        }
        public async Task<bool> DeleteVehicleAsync(Guid id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return false;
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
