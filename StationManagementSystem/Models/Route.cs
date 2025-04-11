using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class Route
    {
        [Key]
        public Guid RouteID { get; set; }  // Khóa chính

        public string DeparturePoint { get; set; } // NVARCHAR(20)
        public string ArrivalPoint { get; set; } // NVARCHAR(20)
        public float Distance { get; set; } // Float
        public bool IsDiscontinued { get; set; } // Bool
        public virtual ICollection<Itinerary> Itineraries { get; set; } = new List<Itinerary>(); // Mối quan hệ với bảng Itinerary
        public virtual ICollection<TicketIssuance> TicketIssuances { get; set; } = new List<TicketIssuance>();
    }
}
