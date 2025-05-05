using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.DTO.Ticket
{
    public class TicketDisplayItem
    {
        public DateTime DepartureTime { get; set; }
        public int RemainingSeats { get; set; }
        public int TotalSeats { get; set; }
        public string CompanyName { get; set; }
        public string LicensePlate { get; set; }
    }
}
