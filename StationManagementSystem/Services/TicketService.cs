using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationManagementSystem.DTO.Ticket;
using StationManagementSystem.DTO.Vehicle;
using StationManagementSystem.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using StationManagementSystem.Views.Employees;

namespace StationManagementSystem.Services
{
    public class TicketService
    {
        private readonly StationContext _context;
        public TicketService()
        {
            _context = new StationContext();
        }
        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _context.Tickets.ToListAsync();
        }
        public async Task<List<TicketDetail>> GetTicketDetailsByTicketIdAsync(Guid ticketId)
        {
            var ticket = await _context.Tickets
                                       .Include(t => t.TicketDetails)
                                       .FirstOrDefaultAsync(t => t.TicketID == ticketId);

            return ticket?.TicketDetails.ToList() ?? new List<TicketDetail>();
        }

        public async Task<Ticket> GetTicketByIdAsync(Guid ticketID)
        {
            return await _context.Tickets
                .FirstOrDefaultAsync(t => t.TicketID == ticketID);
        }

        public float GetTicketPrice_Sit()
        {
            var ticket = _context.Tickets
                .FirstOrDefault(t => t.TicketType.ToLower() == "Seat");

            return ticket != null ? ticket.Price : 0;
        }
        public float GetTicketPrice_Lie()
        {
            var ticket = _context.Tickets
                .FirstOrDefault(t => t.TicketType.ToLower() == "Sleeper");

            return ticket != null ? ticket.Price : 0;
        }
        public async Task<Ticket> CreateTicketAsync(TicketCreateDto ticketDto)
        {
            var ticket = new Ticket
            {
                Price = ticketDto.Price,
                TicketType = ticketDto.TicketType,
                Amount = ticketDto.Amount,
                IssuanceID = ticketDto.IssuanceID
            };
            await _context.Tickets.AddAsync(ticket);


            await _context.SaveChangesAsync();
            return ticket;
        }
        public async Task<TicketDetail> CreateTicketDetailAsync(TicketDetailCreateDto ticketDto)
        {
            var ticket = await _context.Tickets
                           .Include(t => t.TicketDetails)
                           .FirstOrDefaultAsync(t => t.TicketID == ticketDto.TicketID);


            var newDetail = new TicketDetail
            {
                EmployeeID = ticketDto.EmployeeID,
                TicketID = ticketDto.TicketID,
                Status = ticketDto.Status,

                // TicketID không cần set vì EF sẽ gán khi thêm vào Ticket.TicketDetails
            };

            ticket.TicketDetails.Add(newDetail);

            await _context.SaveChangesAsync();
            return newDetail;
        }
    }
}
