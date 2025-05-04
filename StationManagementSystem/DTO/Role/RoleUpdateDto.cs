using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.DTO.Role
{
    public class RoleUpdateDto
    {
        public string RoleName { get; set; } // NVARCHAR(50)
        public string Description { get; set; } // NVARCHAR(MAX)
    }
}
