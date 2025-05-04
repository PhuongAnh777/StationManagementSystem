using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.DTO.Itinerary
{
    public class StopPointCreateDto
    {
        public string Name { get; set; } // NVARCHAR(50)
        public int? StoppingTime { get; set; } // NVARCHAR(10)
        public int StopOrder { get; set; } // NVARCHAR(100)
        public Guid ItineraryID { get; set; }
    }
}
