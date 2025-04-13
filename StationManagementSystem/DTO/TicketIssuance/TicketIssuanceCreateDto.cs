using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationManagementSystem.Models;

namespace StationManagementSystem.DTO.TicketIssuance
{
    public class TicketIssuanceCreateDto
    {
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
        public bool IsDiscontinued { get; set; } // Bool
        public Guid EmployeeID { get; set; } // Khóa ngoại
        public Guid VehicleID { get; set; } // Khóa ngoại
        public Guid RouteID { get; set; } // Khóa ngoại
        public Guid ItineraryID { get; set; }
    }
}
