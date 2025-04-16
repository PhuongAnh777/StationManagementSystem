using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.DTO.Vehicle
{
    public class VehicleDto
    {
        public string LicensePlate { get; set; }
        public string DeparturePoint { get; set; } // NVARCHAR(20)
        public string ArrivalPoint { get; set; } // NVARCHAR(20)
        public float SeatPrice { get; set; }
        public float SleeperPrice { get; set; }
        public DateTime EstimatedDepartureTime { get; set; }
        public string Company { get; set; }
    }
}
