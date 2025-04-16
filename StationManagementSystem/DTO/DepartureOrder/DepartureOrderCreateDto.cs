using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationManagementSystem.Models;

namespace StationManagementSystem.DTO.DepartureOrder
{
    public class DepartureOrderCreateDto
    {
        public string DepartureOrders { get; set; } // NVARCHAR(50)
        public DateTime DepartureTime { get; set; } // DateTime
        public string Status { get; set; } // NVARCHAR(20)
        public bool IsDiscontinued { get; set; } // Bool
        public Guid InvoiceID { get; set; } // Khóa ngoại

        public Guid IssuanceID { get; set; } // Khóa ngoại
    }
}
