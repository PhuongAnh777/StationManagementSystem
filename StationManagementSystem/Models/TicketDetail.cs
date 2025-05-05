using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class TicketDetail
    {
        [Key]
        public Guid TicketDetailID { get; set; }  // Khóa chính

        public string Status { get; set; } // NVARCHAR(20)

        public Guid EmployeeID { get; set; } // Khóa ngoại
        public virtual Employee Employee { get; set; } // Mối quan hệ với bảng Employee
        public Guid TicketID { get; set; } // Khóa ngoại
        public virtual Ticket Ticket { get; set; } // Mối quan hệ với bảng Ticket

    }
}
