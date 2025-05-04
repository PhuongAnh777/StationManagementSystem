using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationManagementSystem.Models;

namespace StationManagementSystem.DTO.Itinerary
{
    public class ItineraryUpdateDto
    {
        public string ItineraryName { get; set; } // NVARCHAR(100)
        public string Terminus { get; set; } // NVARCHAR(20)
        public Guid RouteID { get; set; } // Khóa ngoại
        public ICollection<StopPoint> StopPoints { get; set; } = new List<StopPoint>();
    }
}
