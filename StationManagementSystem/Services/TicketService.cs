using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationManagementSystem.DTO.Ticket;
using StationManagementSystem.DTO.Vehicle;
using StationManagementSystem.Models;

namespace StationManagementSystem.Services
{
    public class TicketService
    {
        private readonly StationContext _context;
        public TicketService()
        {
            _context = new StationContext();
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
    }
}
