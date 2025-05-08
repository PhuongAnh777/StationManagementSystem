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
        public Guid InvoiceID { get; set; } // Khóa ngoại

        public Guid IssuanceID { get; set; } // Khóa ngoại
    }
}
