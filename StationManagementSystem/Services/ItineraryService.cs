using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationManagementSystem.DTO.Itinerary;
using StationManagementSystem.DTO.Owner;
using StationManagementSystem.Models;
using StationManagementSystem.Views.Routes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static TheArtOfDevHtmlRenderer.Adapters.RGraphicsPath;

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
        public async Task<Itinerary> GetItineraryByIdAsync(Guid itineraryID)
        {
            return await _context.Itineraries
                .FirstOrDefaultAsync(v => v.ItineraryID == itineraryID);
        }
        public async Task<List<StopPoint>> GetStopPointsByitineraryIdAsync(Guid itineraryID)
        {
            return await _context.StopPoints
                .Where(sp => sp.Itinerary.ItineraryID == itineraryID)
                .OrderBy(sp => sp.StopOrder)
                .ToListAsync();
        }
        public async Task<Itinerary> CreateItineraryAsync(ItineraryCreateDto dto)
        {
            if (dto.StopPoints.Count == 0) throw new ArgumentException("Itinerary must have at least one stop point");

            var stopPoints = dto.StopPoints
            .Select((detail, index) => new StopPoint
            {
                Name = detail.Name,
                StoppingTime = detail.StoppingTime,
                StopOrder = index + 1, // tự động tăng từ 1
                ItineraryID = detail.ItineraryID
            })
            .ToList();

            var itinerary = new Itinerary
            {
                ItineraryName = dto.ItineraryName,
                Terminus = stopPoints.LastOrDefault()?.Name, // lấy tên điểm dừng cuối
                StopPoints = stopPoints,
                RouteID = dto.RouteID,
            };

            _context.Itineraries.Add(itinerary);
            await _context.SaveChangesAsync();

            return itinerary;
        }
        public async Task<Itinerary> UpdateItineraryAsync(Guid itineraryId, ItineraryUpdateDto dto)
        {
            var itinerary = await _context.Itineraries
                .Include(i => i.StopPoints)
                .FirstOrDefaultAsync(i => i.ItineraryID == itineraryId);

            if (itinerary == null)
                throw new ArgumentException("Itinerary not found");

            // Cập nhật thông tin hành trình
            itinerary.ItineraryName = dto.ItineraryName;
            itinerary.RouteID = dto.RouteID;

            // Cập nhật các điểm dừng
            if (dto.StopPoints.Count == 0)
                throw new ArgumentException("Itinerary must have at least one stop point");

            // Xoá các điểm dừng cũ
            _context.StopPoints.RemoveRange(itinerary.StopPoints);

            // Thêm các điểm dừng mới
            var stopPoints = dto.StopPoints
                .Select((detail, index) => new StopPoint
                {
                    Name = detail.Name,
                    StoppingTime = detail.StoppingTime,
                    StopOrder = index + 1, // tự động tăng từ 1
                    ItineraryID = itinerary.ItineraryID
                })
                .ToList();

            itinerary.StopPoints = stopPoints;

            // Cập nhật điểm dừng cuối
            itinerary.Terminus = stopPoints.LastOrDefault()?.Name;

            await _context.SaveChangesAsync();

            return itinerary;
        }
        public async Task<bool> DeleteItineraryAsync(Guid id)
        {
            var itinerary = await _context.Itineraries
                    .Include(i => i.StopPoints)
                    .FirstOrDefaultAsync(i => i.ItineraryID == id);

            if (itinerary == null)
                return false;

            _context.StopPoints.RemoveRange(itinerary.StopPoints); // Xóa điểm dừng trước
            _context.Itineraries.Remove(itinerary);                // Sau đó xóa lịch trình
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
