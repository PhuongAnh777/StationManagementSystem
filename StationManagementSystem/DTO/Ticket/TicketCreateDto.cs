using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.DTO.Ticket
{
    public class TicketCreateDto
    {
        public float Price { get; set; } // Float
        public string TicketType { get; set; } // NVARCHAR(20)

        public Guid IssuanceID { get; set; } // Khóa ngoại
    }
}
