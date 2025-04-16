using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class StopPoint
    {
        [Key]
        public Guid StopPointID { get; set; }  // Khóa chính

        public string Name { get; set; } // NVARCHAR(50)
        public int? StoppingTime { get; set; } // NVARCHAR(10)
        public int StopOrder { get; set; } // NVARCHAR(100)
        public Guid ItineraryID { get; set; }
        public virtual Itinerary Itinerary { get; set; }
    }
}
