using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class Vehicle
    {
        [Key]
        public Guid VehicleID { get; set; }  // Khóa chính

        public string LicensePlate { get; set; } // NVARCHAR(20)
        public string VehicleType { get; set; } // NVARCHAR(50)
        public int SeatTicket { get; set; } // INT
        public int SleeperTicket { get; set; } // INT
        public int? ManufacturingYear { get; set; } // INT
        public string? Registration { get; set; } // NVARCHAR(100)
        public string? Insurance { get; set; } // NVARCHAR(100)
        public DateTime? InspectionStartDate { get; set; } // DateTime
        public DateTime? InspectionExpiryDate { get; set; } // DateTime
        public DateTime? ImpoundmentDate { get; set; } // DateTime
        public DateTime? ReleaseDate { get; set; } // DateTime

        public Guid OwnerID { get; set; } // Khóa ngoại
        public virtual Owner Owner { get; set; } // Mối quan hệ với bảng Owner

        public virtual ICollection<TicketIssuance> TicketIssuances { get; set; } = new List<TicketIssuance>();
    }
}
