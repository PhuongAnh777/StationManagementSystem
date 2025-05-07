using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.DTO.Invoice
{
    public class InvoiceCreateDto
    {
        //public DateTime InvoiceDate { get; set; } // DateTime
        //public string PaymentStatus { get; set; } // NVARCHAR(25)
        public float Amount { get; set; } // FLOAT

        public int SeatTicket { get; set; } // INT
        public int SleeperTicket { get; set; } // INT
        public float OvernightParkingFee { get; set; } // FLOAT
        public float WaitingFee { get; set; } // FLOAT
        public float WashingFee { get; set; } // FLOAT
        public float FuelCost { get; set; } // FLOAT
        public Guid EmployeeID { get; set; } // Khóa ngoại
    }
}
