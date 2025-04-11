using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.DTO.Owner
{
    public class OwnerUpdateDto
    {
        public string Name { get; set; } // NVARCHAR(100)
        public string IDCard { get; set; } // NVARCHAR(15)
        public string Phone { get; set; } // NVARCHAR(100)
        public string? Address { get; set; } // NVARCHAR(100)
        public string? Email { get; set; } // NVARCHAR(100)
        public string Company { get; set; } // NVARCHAR(100)
        public string? DrivingLicense { get; set; } // NVARCHAR(100)
    }
}
