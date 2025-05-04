using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StationManagementSystem.Models;

namespace StationManagementSystem.DTO.Account
{
    public class AccountUpdateDto
    {
        public string Username { get; set; } // NVARCHAR(50)
        public string Password { get; set; } // NVARCHAR(100)
        public Guid RoleID { get; set; }
    }
}
