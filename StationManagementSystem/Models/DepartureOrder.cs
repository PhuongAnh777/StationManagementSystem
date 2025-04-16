using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class DepartureOrder
    {
        [Key]
        public Guid OrderID { get; set; } // Khóa chính

        public string DepartureOrders { get; set; } // NVARCHAR(50)
        public DateTime DepartureTime { get; set; } // DateTime
        public string Status { get; set; } // NVARCHAR(20)
        public Guid InvoiceID { get; set; } // Khóa ngoại
        public virtual Invoice Invoice { get; set; } // Mối quan hệ với bảng Invoice

        public Guid IssuanceID { get; set; } // Khóa ngoại
        public virtual TicketIssuance TicketIssuance { get; set; } // Mối quan hệ với bảng TicketIssuance
    }
}
