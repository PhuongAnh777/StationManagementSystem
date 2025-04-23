using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.DTO.Route
{
    public class RouteUpdateDto
    {
        public string DeparturePoint { get; set; } // NVARCHAR(20)
        public string ArrivalPoint { get; set; } // NVARCHAR(20)
        public float Distance { get; set; } // Float
    }
}
