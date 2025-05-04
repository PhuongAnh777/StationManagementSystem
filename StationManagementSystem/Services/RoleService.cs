using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationManagementSystem.DTO.Account;
using StationManagementSystem.DTO.Role;
using StationManagementSystem.DTO.Route;
using StationManagementSystem.Models;
using StationManagementSystem.Views.Employees;

namespace StationManagementSystem.Services
{
    public class RoleService
    {
        private readonly StationContext _context;
        public RoleService()
        {
            _context = new StationContext();
        }
        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task<Role> GetRoleByIdAsync(Guid roleId)
        {
            return await _context.Roles
                .FirstOrDefaultAsync(p => p.RoleID == roleId);
        }
        //public async Task<IEnumerable<string>> GetAllRoleNameAsync()
        //{
        //    return await _context.Roles
        //        .Select(o => o.RoleName)
        //        .Distinct()
        //        .ToListAsync();
        //}
        public async Task<bool> IsRoleNameExistsAsync(string roleName)
        {
            var user = await _context.Roles
                .FirstOrDefaultAsync(p => p.RoleName == roleName);
            return user != null;
        }
        public async Task<Role> CreateRoleAsync(RoleCreateDto roleDto)
        {
            var role = new Role
            {
                RoleName = roleDto.RoleName,
                Description = roleDto.Description,
            };
            await _context.Roles.AddAsync(role);


            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> UpdateRoleAsync(Guid roleId, RoleUpdateDto roleDto)
        {
            if (roleDto == null)
                throw new ArgumentNullException(nameof(roleDto), "Role data is required.");

            var role = await _context.Roles.FirstOrDefaultAsync(p => p.RoleID == roleId);

            if (role == null)
                throw new KeyNotFoundException($"Role with {roleId} not found.");

            // Update product properties
            role.RoleName = roleDto.RoleName;
            role.Description = roleDto.Description;

            await _context.SaveChangesAsync();

            return role;

        }
        //public async Task<Account> UpdateAccountStatusAsync(String userName)
        //{
        //    var account = await _context.Accounts.FirstOrDefaultAsync(p => p.Username == userName);

        //    if (account == null)
        //        throw new KeyNotFoundException($"Account with {userName} not found.");

        //    // Update product properties

        //    account.IsDiscontinued = true;

        //    // Save changes to the database, this will automatically check the RowVersion
        //    await _context.SaveChangesAsync();

        //    return account;

        //}

        public async Task<bool> DeleteRoleAsync(Guid roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            if (role == null)
            {
                return false;
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
