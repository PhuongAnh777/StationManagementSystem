using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.DTO.Ticket
{
    public class TicketDetailCreateDto
    {

        public string Status { get; set; } // NVARCHAR(20)

        public Guid EmployeeID { get; set; } // Khóa ngoại
        public Guid TicketID { get; set; } // Khóa ngoại
    }
}
