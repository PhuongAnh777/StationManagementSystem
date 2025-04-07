using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StationManagementSystem.Models
{
    public class Permission
    {
        [Key]
        public Guid PermissionID { get; set; } // Khóa chính

        public string PermissionName { get; set; } // NVARCHAR(50)
        public string Description { get; set; } // NVARCHAR(MAX)

        public virtual ICollection<RolesPermission> RolesPermissions { get; set; } = new List<RolesPermission>(); // Mối quan hệ với bảng RolePermissions
    }
}
