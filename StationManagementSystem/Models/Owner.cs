using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class Owner
    {
        [Key]
        public Guid OwnerID { get; set; }  // Khóa chính

        public string Name { get; set; } // NVARCHAR(100)
        public string? IDCard { get; set; } // NVARCHAR(15)
        public string? Phone { get; set; } // NVARCHAR(100)
        public string? Address { get; set; } // NVARCHAR(100)
        public string? Email { get; set; } // NVARCHAR(100)
        public bool IsDiscontinued { get; set; } // Bool
        public string? Company { get; set; } // NVARCHAR(100)
        public string? DrivingLicense { get; set; } // NVARCHAR(100)

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>(); // Mối quan hệ với bảng Vehicles
    }
}
