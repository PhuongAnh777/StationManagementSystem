using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class Itinerary
    {
        [Key]
        public Guid ItineraryID { get; set; }  // Khóa chính

        public string ItineraryName { get; set; } // NVARCHAR(100)
        public string Terminus { get; set; } // NVARCHAR(20)

        public Guid RouteID { get; set; } // Khóa ngoại
        public virtual Route Route { get; set; } // Mối quan hệ với bảng Route
        public virtual ICollection<TicketIssuance> TicketIssuances { get; set; }
        public virtual ICollection<StopPoint> StopPoints { get; set; } = new List<StopPoint>(); // Mối quan hệ với bảng DepartureOrder
    }
}
