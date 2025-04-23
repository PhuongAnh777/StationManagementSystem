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
        public async Task<Route> UpdateRouteAsync(Guid routeId, RouteUpdateDto routeDto)
        {
            if (routeDto == null)
                throw new ArgumentNullException(nameof(routeDto), "route data is required.");

            var route = await _context.Routes.FirstOrDefaultAsync(p => p.RouteID == routeId);

            if (route == null)
                throw new KeyNotFoundException($"Route with ID {routeId} not found.");

            // Update product properties

            route.DeparturePoint = routeDto.DeparturePoint;
            route.ArrivalPoint = routeDto.ArrivalPoint;
            route.Distance = routeDto.Distance;

            // Save changes to the database, this will automatically check the RowVersion
            await _context.SaveChangesAsync();

            return route;
        }
        public async Task<Route> UpdateRouteStatusAsync(Guid routeId)
        {
            var route = await _context.Routes.FirstOrDefaultAsync(p => p.RouteID == routeId);

            if (route == null)
                throw new KeyNotFoundException($"Route with ID {routeId} not found.");

            // Update product properties

            route.IsDiscontinued = true;

            // Save changes to the database, this will automatically check the RowVersion
            await _context.SaveChangesAsync();

            return route;

        }
        public async Task<bool> DeleteRouteAsync(Guid id)
        {
            var route = await _context.Routes.FindAsync(id);
            if (route == null)
            {
                return false;
            }

            _context.Routes.Remove(route);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
