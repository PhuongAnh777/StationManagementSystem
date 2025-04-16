using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationManagementSystem.DTO.Account;
using StationManagementSystem.DTO.DepartureOrder;
using StationManagementSystem.Models;

namespace StationManagementSystem.Services
{
    public class DepartureOrderService
    {
        private readonly StationContext _context;
        public DepartureOrderService()
        {
            _context = new StationContext();
        }
        // Phương thức để lấy danh sách các đơn hàng khởi hành
        public async Task<IEnumerable<DepartureOrder>> GetAllDepartureOrders()
        {
            return await _context.DepartureOrders.ToListAsync();
        }
        // Phương thức để thêm một đơn hàng khởi hành mới
        public async Task<DepartureOrder> CreateDepartureOrderAsync(DepartureOrderCreateDto departureOrderDto)
        {
            var departureOrder = new DepartureOrder
            {
                DepartureOrders = departureOrderDto.DepartureOrders,
                DepartureTime = departureOrderDto.DepartureTime,
                Status = "Departed",
                
            };
            await _context.DepartureOrders.AddAsync(departureOrder);


            await _context.SaveChangesAsync();
            return departureOrder;
        }

    }
}
