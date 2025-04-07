using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class Invoice
    {
        [Key]
        public Guid InvoiceID { get; set; } // Khóa chính

        public DateTime InvoiceDate { get; set; } // DateTime
        public string PaymentStatus { get; set; } // NVARCHAR(25)
        public float Amount { get; set; } // FLOAT

        public int SeatTicket { get; set; } // INT
        public int SleeperTicket { get; set; } // INT
        public float OvernightParkingFee { get; set; } // FLOAT
        public float WaitingFee { get; set; } // FLOAT
        public float WashingFee { get; set; } // FLOAT
        public float FuelCost { get; set; } // FLOAT

        public Guid EmployeeID { get; set; } // Khóa ngoại
        public virtual Employee Employee { get; set; } // Mối quan hệ với bảng Employee
        public virtual DepartureOrder DepartureOrder { get; set; }
    }
}
