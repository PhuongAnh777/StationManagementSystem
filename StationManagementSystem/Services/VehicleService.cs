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
                OwnerID = vehicleDto.OwnerID
            };
            await _context.Vehicles.AddAsync(vehicle);


            await _context.SaveChangesAsync();
            return vehicle;
        }
    }
}
