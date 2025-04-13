using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationManagementSystem.DTO.Route;
using StationManagementSystem.DTO.Vehicle;
using StationManagementSystem.Models;

namespace StationManagementSystem.Services
{
    public class RouteService
    {
        private readonly StationContext _context;
        public RouteService()
        {
            _context = new StationContext();
        }
        public async Task<IEnumerable<Route>> GetAllRoutesAsync()
        {
            return await _context.Routes.ToListAsync();
        }
        public async Task<IEnumerable<Route>> GetActiveRoutesAsync()
        {
            return await _context.Routes
                .Where(v => v.IsDiscontinued == false) 
                .ToListAsync();
        }
        public async Task<Route> GetRouteByIdAsync(Guid routeID)
        {
            return await _context.Routes
                .FirstOrDefaultAsync(v => v.RouteID == routeID);
        }
        public async Task<Route> CreateRouteAsync(RouteCreateDto routeDto)
        {
            var route = new Route
            {
                ArrivalPoint = routeDto.ArrivalPoint,
                DeparturePoint = routeDto.DeparturePoint,
                Distance = routeDto.Distance,
                IsDiscontinued = routeDto.IsDiscontinued
            };
            await _context.Routes.AddAsync(route);


            await _context.SaveChangesAsync();
            return route;
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
