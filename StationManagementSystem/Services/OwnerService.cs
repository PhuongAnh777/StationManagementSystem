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
                .FirstOrDefaultAsync(v => v.OwnerID == ownerId);
        }
        public async Task<Owner> CreateOwnerAsync(OwnerCreateDto ownerDto)
        {
            var owner = new Owner
            {
                DrivingLicense = ownerDto.DrivingLicense,
                Name = ownerDto.Name,
                Address = ownerDto.Address,
                IDCard = ownerDto.IDCard,
                Phone = ownerDto.Phone,
                IsDiscontinued = false,
                Email = ownerDto.Email,
                Company = ownerDto.Company,
                OwnerID = Guid.NewGuid() // Tạo ID ngẫu nhiên

            };
            await _context.Owners.AddAsync(owner);


            await _context.SaveChangesAsync();
            return owner;
        }
    }
}
