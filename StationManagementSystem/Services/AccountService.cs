using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationManagementSystem.DTO.Account;
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
        public async Task<IEnumerable<Account>> GetAllUserAccountsAsync()
        {
            return await _context.Accounts.ToListAsync();
        }
        public async Task<IEnumerable<string>> GetAllUserNamesAsync()
        {
            return await _context.Accounts.Select(c => c.Username).ToListAsync();
        }
        //public async Task<Account> GetUserAccountByIdAsync(String username)
        //{
        //    return await _context.Accounts
        //        .FirstOrDefaultAsync(p => p.Username == username);
        //}
        public async Task<Account> GetUserAccountByUserNameAsync(string userName)
        {
            return await _context.Accounts
                .FirstOrDefaultAsync(p => p.Username == userName);
        }
        public async Task<Account> CheckLogin(string username, string password)
        {
            return await _context.Accounts
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == password);
        }
        public async Task<Account> CreateAccountAsync(AccountCreateDto accountDto)
        {
            var account = new Account
            {
                Username = accountDto.Username,
                Password = accountDto.Password,
            };
            await _context.Accounts.AddAsync(account);


            await _context.SaveChangesAsync();
            return account;
        }

        //public async Task<Models.Customer> UpdateProductAsync(Guid ProducId, ProductUpdateDto productDto)
        //{
        //    if (productDto == null)
        //        throw new ArgumentNullException(nameof(productDto), "Product data is required.");

        //    var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductID == ProducId);

        //    if (product == null)
        //        throw new KeyNotFoundException($"Product with ID {ProducId} not found.");

        //    // Update product properties

        //    product.MedicineID = productDto.MedicineID;
        //    product.RegistrationNumber = productDto.RegistrationNumber;
        //    product.CountryOfOrigin = productDto.CountryOfOrigin;
        //    product.Name = productDto.Name;
        //    product.ActiveIngredient = productDto.ActiveIngredient;
        //    product.Dosage = productDto.Dosage;
        //    product.Packaging = productDto.Packaging;
        //    product.Unit = productDto.Unit;
        //    product.OriginalPrice = productDto.OriginalPrice;
        //    product.SellingPrice = productDto.SellingPrice;
        //    product.Description = productDto.Description;
        //    product.Manufacturer = productDto.Manufacturer;
        //    product.StockQuantity = productDto.StockQuantity;
        //    product.ExpiryDate = productDto.ExpiryDate;
        //    product.CategoryID = productDto.CategoryID;
        //    product.SupplierID = productDto.SupplierID;
        //    product.Image = productDto.Image;
        //    product.IsDiscontinued = productDto.IsDiscontinued;
        //    // Save changes to the database, this will automatically check the RowVersion
        //    await _context.SaveChangesAsync();

        //    return product;

        //}

        public async Task<bool> DeleteUserAccountAsync(Guid id)
        {
            var userAccount = await _context.Accounts.FindAsync(id);
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
