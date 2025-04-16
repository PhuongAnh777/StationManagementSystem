using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class Employee
    {
        [Key]
        public Guid EmployeeID { get; set; }  // Khóa chính

        public string FullName { get; set; } // NVARCHAR(50)
        public string Phone { get; set; } // NVARCHAR(10)
        public string Address { get; set; } // NVARCHAR(100)
        public string Email { get; set; } // NVARCHAR(100)
        public DateTime? BirthDate { get; set; } // DateTime
        public bool Gender { get; set; } // BIT 0 là nam, 1 là nữ vì phụ nữ luôn true
        public bool IsDiscontinued { get; set; } // Bool
        public virtual Account Account { get; set; }
        public virtual ICollection<DepartureOrder> Orders { get; set; } = new List<DepartureOrder>(); // Mối quan hệ với bảng Order
        public virtual ICollection<TicketDetail> TicketDetails { get; set; } = new List<TicketDetail>(); 
        public virtual ICollection<TicketIssuance> TicketIssuances { get; set; } = new List<TicketIssuance>();
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
