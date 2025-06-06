﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.DTO.Account
{
    public class AccountCreateDto
    {
        public string Username { get; set; } // NVARCHAR(50)

        public string Password { get; set; } // NVARCHAR(100)z
        public Guid RoleID { get; set; }
        public Guid EmployeeID { get; set; } // Khóa ngoại
    }
}
