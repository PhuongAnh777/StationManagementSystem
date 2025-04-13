using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class Account
    {
        [Key]
        public string Username { get; set; } // NVARCHAR(50)
        public string Password { get; set; } // NVARCHAR(100)
        public string Status { get; set; } // NVARCHAR(25)
        public DateTime CreatedAt { get; set; } // DateTime
        public bool IsDiscontinued { get; set; } // Bool
        public Guid RoleID { get; set; } // Khóa ngoại
        public virtual Role Role { get; set; } // Mối quan hệ với bảng Role
        public Guid EmployeeID { get; set; } // Khóa ngoại
        public virtual Employee Employee { get; set; } // Mối quan hệ với bảng Employee
    }
}
