using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationManagementSystem.Models;

namespace StationManagementSystem.Services
{
    public class ItineraryService
    {
        private readonly StationContext _context;
        public ItineraryService()
        {
            _context = new StationContext();
        }
        public async Task<IEnumerable<Itinerary>> GetAllItinerariesAsync()
        {
            return await _context.Itineraries.ToListAsync();
        }
        //public async Task<IEnumerable<Itinerary>> GetActivetinerariesAsync()
        //{
        //    return await _context.Itineraries
        //        .Where(v => v.IsDiscontinued == false)
        //        .ToListAsync();
        //}
        public async Task<Itinerary> GetItineraryByIdAsync(Guid routeID)
        {
            return await _context.Itineraries
                .FirstOrDefaultAsync(v => v.RouteID == routeID);
        }
    }
}
