using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationManagementSystem.DTO.Invoice;
using StationManagementSystem.Models;

namespace StationManagementSystem.Services
{
    public class InvoiceService
    {
        private readonly StationContext _context;
        public InvoiceService()
        {
            _context = new StationContext();
        }
        public async Task<IEnumerable<Invoice>> GetAllInvoicesAsync()
        {
            return await _context.Invoices.ToListAsync();
        }
        public async Task<Invoice> GetInvoiceByIdAsync(Guid invoiceId)
        {
            return await _context.Invoices
                .FirstOrDefaultAsync(p => p.InvoiceID == invoiceId);
        }
        public async Task<Invoice> CreateInvoiceAsync(InvoiceCreateDto employeeDto)
        {
            var invoice = new Invoice
            {
                InvoiceDate = employeeDto.InvoiceDate,
                PaymentStatus = employeeDto.PaymentStatus,
                Amount = employeeDto.Amount,
                SeatTicket = employeeDto.SeatTicket,
                SleeperTicket = employeeDto.SleeperTicket,
                OvernightParkingFee = employeeDto.OvernightParkingFee,
                WaitingFee = employeeDto.WaitingFee,
                WashingFee = employeeDto.WashingFee,
                FuelCost = employeeDto.FuelCost,
                IsDiscontinued = false,
                EmployeeID = employeeDto.EmployeeID

            };
            await _context.Invoices.AddAsync(invoice);


            await _context.SaveChangesAsync();
            return invoice;
        }

        //public async Task<Models.Employee> UpdateEmployeeAsync(Guid employeeId, EmployeeUpdateDto employeeDto)
        //{
        //    if (employeeDto == null)
        //        throw new ArgumentNullException(nameof(employeeDto), "Employee data is required.");

        //    var employee = await _context.Employees.FirstOrDefaultAsync(p => p.EmployeeID == employeeId);

        //    if (employee == null)
        //        throw new KeyNotFoundException($"Employee with ID {employeeId} not found.");

        //    // Update product properties

        //    employee.FullName = employeeDto.FullName;
        //    employee.Gender = employeeDto.Gender;
        //    employee.Phone = employeeDto.Phone;
        //    employee.Email = employeeDto.Email;
        //    employee.BirthDate = employeeDto.BirthDate;
        //    employee.Address = employeeDto.Address;
        //    // Save changes to the database, this will automatically check the RowVersion
        //    await _context.SaveChangesAsync();

        //    return employee;

        //}
        //public async Task<Models.Employee> UpdateEmployeeStatusAsync(Guid employeeId)
        //{
        //    var employee = await _context.Employees.FirstOrDefaultAsync(p => p.EmployeeID == employeeId);

        //    if (employee == null)
        //        throw new KeyNotFoundException($"Employee with ID {employeeId} not found.");

        //    // Update product properties

        //    employee.IsDiscontinued = true;

        //    // Save changes to the database, this will automatically check the RowVersion
        //    await _context.SaveChangesAsync();

        //    return employee;

        //}
        //public async Task<bool> DeleteEmployeeAsync(Guid id)
        //{
        //    var employee = await _context.Employees.FindAsync(id);
        //    if (employee == null)
        //    {
        //        return false;
        //    }

        //    _context.Employees.Remove(employee);
        //    await _context.SaveChangesAsync();

        //    return true;
        //}
    }
}
