using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class TicketIssuance
    {
        [Key]
        public Guid IssuanceID { get; set; }  // Khóa chính

        public DateTime CreatedAt { get; set; } // DateTime
        public DateTime StartDate { get; set; } // DateTime
        public DateTime EndDate { get; set; } // DateTime
        public string OperatingSchedule { get; set; } // NVARCHAR(20)
        public int MonthlyFrequency { get; set; } // INT
        public string PaymentMethod { get; set; } // NVARCHAR(100)
        public float ServiceFee { get; set; } // Float
        public float TicketSalesCommission { get; set; } // Float
        public int SeatTicket { get; set; } // INT
        public int SleeperTicket { get; set; } // INT
        public string Status { get; set; } // NVARCHAR(20)
        public string Notes { get; set; } // NVARCHAR(MAX)
        public DateTime EstimatedDepartureTime { get; set; } // DateTime
        public DateTime EstimatedArrivalTime { get; set; } // DateTime
        public Guid EmployeeID { get; set; } // Khóa ngoại
        public virtual Employee Employee { get; set; } // Mối quan hệ với bảng Employee

        public Guid VehicleID { get; set; } // Khóa ngoại
        public virtual Vehicle Vehicle { get; set; } // Mối quan hệ với bảng Vehicle
        public Guid ItineraryID { get; set; }
        public virtual Itinerary Itinerary { get; set; }
        public virtual DepartureOrder DepartureOrder { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
