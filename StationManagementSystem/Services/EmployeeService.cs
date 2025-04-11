using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StationManagementSystem.DTO.Employee;
using StationManagementSystem.Models;

namespace StationManagementSystem.Services
{
    public class EmployeeService
    {
        private readonly StationContext _context;
        public EmployeeService()
        {
            _context = new StationContext();
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<IEnumerable<string>> GetAllEmployeesNameAsync()
        {
            return await _context.Employees.Select(c => c.FullName).ToListAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(Guid employeeId)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(p => p.EmployeeID == employeeId);
        }
        //public async Task<Employee> GetEmployeeByAccountAsync(Guid? accountId)
        //{
        //    return await _context.Employees
        //        .FirstOrDefaultAsync(p => p.AccountID == accountId);
        //}
        public async Task<Employee> CreateEmployeeAsync(EmployeeCreateDto employeeDto)
        {
            var employee = new Employee
            {
                FullName = employeeDto.FullName,
                Gender = employeeDto.Gender,
                Phone = employeeDto.Phone,
                Email = employeeDto.Email,
                BirthDate = employeeDto.BirthDate,
                Address = employeeDto.Address,
                IsDiscontinued = false,
            };
            await _context.Employees.AddAsync(employee);


            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Models.Employee> UpdateEmployeeAsync(Guid employeeId, EmployeeUpdateDto employeeDto)
        {
            if (employeeDto == null)
                throw new ArgumentNullException(nameof(employeeDto), "Employee data is required.");

            var employee = await _context.Employees.FirstOrDefaultAsync(p => p.EmployeeID == employeeId);

            if (employee == null)
                throw new KeyNotFoundException($"Employee with ID {employeeId} not found.");

            // Update product properties

            employee.FullName = employeeDto.FullName;
            employee.Gender = employeeDto.Gender;
            employee.Phone = employeeDto.Phone;
            employee.Email = employeeDto.Email;
            employee.BirthDate = employeeDto.BirthDate;
            employee.Address = employeeDto.Address;
            // Save changes to the database, this will automatically check the RowVersion
            await _context.SaveChangesAsync();

            return employee;

        }
        public async Task<Models.Employee> UpdateEmployeeStatusAsync(Guid employeeId)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(p => p.EmployeeID == employeeId);

            if (employee == null)
                throw new KeyNotFoundException($"Employee with ID {employeeId} not found.");

            // Update product properties

            employee.IsDiscontinued = true;
            
            // Save changes to the database, this will automatically check the RowVersion
            await _context.SaveChangesAsync();

            return employee;

        }
        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return false;
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
