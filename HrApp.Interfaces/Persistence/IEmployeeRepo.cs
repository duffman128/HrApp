using HrApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Interfaces.Persistence
{
    public interface IEmployeeRepo
    {
        public IQueryable<Employee> GetEmployeesQueryable();
        public Task<Employee> GetEmployeeAsync(Guid employeeId);
        public Task AddEmployeeAsync(Employee employee);
        public Task UpdateEmployeeAsync();
    }
}
