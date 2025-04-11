using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationManagementSystem.DTO.Owner;
using StationManagementSystem.DTO.Vehicle;
using StationManagementSystem.Models;

namespace StationManagementSystem.Services
{
    public class OwnerService
    {
        private readonly StationContext _context;
        public OwnerService()
        {
            _context = new StationContext();
        }
        public async Task<IEnumerable<Owner>> GetAllOwnersAsync()
        {
            return await _context.Owners.ToListAsync();
        }
        public async Task<Owner> GetOwnerByIdAsync(Guid ownerId)
        {
            return await _context.Owners
                .FirstOrDefaultAsync(p => p.OwnerID == ownerId);
        }
        //public async Task<IEnumerable<string>> GetAllCompaniesAsync()
        //{
        //    return await _context.Owners
        //        .Select(o => o.Company)
        //        .Distinct()
        //        .ToListAsync();
        //}
        public async Task<Owner> CreateOwnerAsync(OwnerCreateDto ownerDto)
        {
            var owner = new Owner
            {
                DrivingLicense = ownerDto.DrivingLicense,
                Name = ownerDto.Name,
                Address = ownerDto.Address,
                IDCard = ownerDto.IDCard,
                Phone = ownerDto.Phone,
                Email = ownerDto.Email,
                Company = ownerDto.Company,
                OwnerID = Guid.NewGuid() // Tạo ID ngẫu nhiên

            };
            await _context.Owners.AddAsync(owner);


            await _context.SaveChangesAsync();
            return owner;
        }
        public async Task<bool> IsTransportUnitExists(string transportUnitName)
        {
            // Đợi Task hoàn thành và lấy kết quả từ nó
            var existingUnits = await GetAllOwnersAsync();

            // Bây giờ mới sử dụng Any() trên collection
            return existingUnits.Any(u => u.Company.Equals(transportUnitName, StringComparison.OrdinalIgnoreCase));
        }

        public async Task<Owner> UpdateOwnerAsync(Guid ownerId, OwnerUpdateDto ownerDto)
        {
            if (ownerDto == null)
                throw new ArgumentNullException(nameof(ownerDto), "vehicle data is required.");

            var owner = await _context.Owners.FirstOrDefaultAsync(p => p.OwnerID == ownerId);

            if (owner == null)
                throw new KeyNotFoundException($"Employee with ID {ownerId} not found.");

            // Update product properties

            owner.Name = ownerDto.Name;
            owner.IDCard = ownerDto.IDCard;
            owner.Phone = ownerDto.Phone;
            owner.Address = ownerDto.Address;
            owner.Email = ownerDto.Email;
            owner.Company = ownerDto.Company;
            owner.DrivingLicense = ownerDto.DrivingLicense;


            // Save changes to the database, this will automatically check the RowVersion
            await _context.SaveChangesAsync();

            return owner;

        }
        //public async Task<Owner> UpdateOwnerStatusAsync(Guid ownerId)
        //{

        //    var owner = await _context.Owners.FirstOrDefaultAsync(p => p.OwnerID == ownerId);

        //    if (owner == null)
        //        throw new KeyNotFoundException($"Employee with ID {ownerId} not found.");

        //    // Update product properties
        //    owner.IsDiscontinued = true;

        //    // Save changes to the database, this will automatically check the RowVersion
        //    await _context.SaveChangesAsync();

        //    return owner;

        //}
        //public async Task<bool> DeleteOwnerAsync(Guid id)
        //{
        //    var owner = await _context.Owners.FindAsync(id);
        //    if (owner == null)
        //    {
        //        return false;
        //    }

        //    _context.Owners.Remove(owner);
        //    await _context.SaveChangesAsync();

        //    return true;
        //}
    }
}
