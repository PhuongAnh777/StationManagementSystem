using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.DTO.Employee
{
    public class EmployeeCreateDto
    {
        public Guid EmployeeID { get; set; }  // Khóa chính

        public string FullName { get; set; } // NVARCHAR(50)
        public string Phone { get; set; } // NVARCHAR(10)
        public string Address { get; set; } // NVARCHAR(100)
        public string Email { get; set; } // NVARCHAR(100)
        public DateTime? BirthDate { get; set; } // DateTime
        public bool Gender { get; set; } // BIT 0 là nam, 1 là nữ vì phụ nữ luôn true
    }
}
