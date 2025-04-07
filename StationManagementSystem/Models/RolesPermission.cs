using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class RolesPermission
    {
        [Key]
        public Guid RoleID { get; set; } // Khóa ngoại
        public Guid PermissionID { get; set; } // Khóa ngoại

        public DateTime CreatedAt { get; set; } // DateTime

        public virtual Role Role { get; set; } // Mối quan hệ với bảng Role
        public virtual Permission Permission { get; set; } // Mối quan hệ với bảng Permission
    }
}
