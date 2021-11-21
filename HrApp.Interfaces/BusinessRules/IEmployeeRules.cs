using HrApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Interfaces.BusinessRules
{
    public interface IEmployeeRules
    {
        public Task<IEnumerable<Employee>> GetEmployeesAsync();
        public Task<Employee> GetEmployeeAsync(Guid employeeId);
        public Task<Employee> GetEmployeeByNumberAsync(int employeeNumber);
        public Task AddEmployeeAsync(Employee employee);
        public Task UpdateEmployeeAsync(Employee employee);
    }
}
