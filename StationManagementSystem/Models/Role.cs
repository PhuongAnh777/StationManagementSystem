using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class Role
    {
        [Key]
        public Guid RoleID { get; set; } // Khóa chính

        public string RoleName { get; set; } // NVARCHAR(50)
        public string Description { get; set; } // NVARCHAR(MAX)

        public virtual ICollection<RolesPermission> RolesPermissions { get; set; } = new List<RolesPermission>(); // Mối quan hệ với bảng RolePermissions
        public virtual ICollection<Account> Accounts { get; set; } = new List<Account>(); // Mối quan hệ với bảng Accounts
    }
}
