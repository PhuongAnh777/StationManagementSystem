using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using StationManagementSystem.DTO.Account;
using StationManagementSystem.DTO.Employee;
using StationManagementSystem.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace StationManagementSystem.Services
{
    public class AccountService
    {
        private readonly StationContext _context;
        public AccountService()
        {
            _context = new StationContext();
        }
        public async Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }
        public async Task<IEnumerable<string>> GetAllUserNamesAsync()
        {
            return await _context.Accounts.Select(c => c.Username).ToListAsync();
        }
        public async Task<Account> GetAccountByUserNameAsync(string userName)
        {
            return await _context.Accounts
                .FirstOrDefaultAsync(p => p.Username == userName);
        }
        public async Task<Account> GetAccountByEmployeeIdAsync(Guid employeeId)
        {
            return await _context.Accounts
                .FirstOrDefaultAsync(p => p.EmployeeID == employeeId);
        }
        public async Task<Account> CheckLogin(string username, string password)
        {
            return await _context.Accounts
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
        public async Task<bool> IsUsernameExistsAsync(string username)
        {
            var user = await GetAccountByUserNameAsync(username);
            return user != null;
        }
        public async Task<Account> CreateAccountAsync(AccountCreateDto accountDto)
        {
            var account = new Account
            {
                Username = accountDto.Username,
                Password = accountDto.Password,
                RoleID = accountDto.RoleID,
                EmployeeID = accountDto.EmployeeID,
            };
            await _context.Accounts.AddAsync(account);


            await _context.SaveChangesAsync();
            return account;
        }

        public async Task<Account> UpdateAccountAsync(String userName, AccountUpdateDto accountDto)
        {
            if (accountDto == null)
                throw new ArgumentNullException(nameof(accountDto), "Account data is required.");

            var account = await _context.Accounts.FirstOrDefaultAsync(p => p.Username == userName);

            if (account == null)
                throw new KeyNotFoundException($"Account with {userName} not found.");

            // Update product properties

            account.Username = accountDto.Username;
            account.Password = accountDto.Password;
            account.RoleID = accountDto.RoleID;

            await _context.SaveChangesAsync();

            return account;

        }
        public async Task<Account> UpdateAccountStatusAsync(String userName)
        {
            var account = await _context.Accounts.FirstOrDefaultAsync(p => p.Username == userName);

            if (account == null)
                throw new KeyNotFoundException($"Account with {userName} not found.");

            // Update product properties

            account.IsDiscontinued = true;

            // Save changes to the database, this will automatically check the RowVersion
            await _context.SaveChangesAsync();

            return account;

        }

        public async Task<bool> DeleteAccountAsync(String userName)
        {
            var userAccount = await _context.Accounts.FindAsync(userName);
            if (userAccount == null)
            {
                return false;
            }

            _context.Accounts.Remove(userAccount);
            await _context.SaveChangesAsync();

            return true;
        }

        //private async Task<bool> IsUsernameExistsAsync(string username)
        //{
        //    var user = await GetUserByUsernameAsync(username);
        //    return user != null;
        //}
    }
}
