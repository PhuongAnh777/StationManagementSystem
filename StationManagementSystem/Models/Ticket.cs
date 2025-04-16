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
        public string TicketType { get; set; } // NVARCHAR(20)

        public Guid IssuanceID { get; set; } // Khóa ngoại
        public virtual TicketIssuance TicketIssuance { get; set; } // Mối quan hệ với bảng TicketIssuance
        public virtual ICollection<TicketDetail> TicketDetails { get; set; } = new List<TicketDetail>();
    }
}
