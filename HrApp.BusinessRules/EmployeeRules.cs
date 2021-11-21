using HrApp.Interfaces.BusinessRules;
using HrApp.Interfaces.Persistence;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.BusinessRules
{
    public class EmployeeRules : IEmployeeRules
    {
        private readonly IEmployeeRepo employeeRepo;

        public EmployeeRules(IEmployeeRepo _employeeRepo)
        {
            employeeRepo = _employeeRepo;
        }

        public async Task<Employee> GetEmployeeByNumberAsync(int employeeNumber)
        {
            var employee = await employeeRepo.GetEmployeesQueryable().Where(e => e.EmployeeNumber == employeeNumber).FirstOrDefaultAsync();
            return employee;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            var dbEmployee = await GetEmployeeByNumberAsync(employee.EmployeeNumber);
            if (dbEmployee is null)
            {
                await employeeRepo.AddEmployeeAsync(employee);
                return;
            }
            throw new ArgumentException("Employee already exists.");

        }

        public async Task<Employee> GetEmployeeAsync(Guid employeeId)
        {
            var employee = await employeeRepo.GetEmployeeAsync(employeeId);
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = await employeeRepo.GetEmployeesQueryable().ToListAsync();
            return employees;
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            var dbEmployee = await GetEmployeeAsync(employee.Id);
            if(dbEmployee is not null)
            {
                dbEmployee.FirstName = employee.FirstName;
                dbEmployee.LastName = employee.LastName;
                dbEmployee.DateOfBirth = employee.DateOfBirth;
                dbEmployee.TimeStampModified = DateTime.Now;

                await employeeRepo.UpdateEmployeeAsync();
                return;
            }
            throw new ArgumentException("Employee does not exist.");
        }
    }
}
