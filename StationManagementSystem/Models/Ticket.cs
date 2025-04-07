using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class Ticket
    {
        [Key]
        public Guid TicketID { get; set; }  // Khóa chính

        public float Price { get; set; } // Float
        public string SeatNumber { get; set; } // NVARCHAR(15)
        public string TicketType { get; set; } // NVARCHAR(20)
        public string Status { get; set; } // NVARCHAR(20)

        public Guid EmployeeID { get; set; } // Khóa ngoại
        public virtual Employee Employee { get; set; } // Mối quan hệ với bảng Employee

        public Guid IssuanceID { get; set; } // Khóa ngoại
        public virtual TicketIssuance TicketIssuance { get; set; } // Mối quan hệ với bảng TicketIssuance
    }
}
