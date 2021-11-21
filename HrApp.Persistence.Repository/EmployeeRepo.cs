using HrApp.Interfaces.Persistence;
using HrApp.Models;
using HrApp.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Persistence.Repository
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly HrAppContext hrAppContext;

        public EmployeeRepo(HrAppContext _hrAppContext)
        {
            hrAppContext = _hrAppContext;
        }

        public  async Task AddEmployeeAsync(Employee employee)
        {
            await hrAppContext.AddAsync(employee);
            await hrAppContext.SaveChangesAsync();
        }

        public async Task<Employee> GetEmployeeAsync(Guid employeeId)
        {
            var employee = await GetEmployeesQueryable().Where(e => e.Id == employeeId).FirstOrDefaultAsync();
            return employee;
        }

        public IQueryable<Employee> GetEmployeesQueryable()
        {
            return hrAppContext.Employees.Where(e => e.IsActive);
        }

        public async Task UpdateEmployeeAsync()
        {
            await hrAppContext.SaveChangesAsync();
        }
    }
}
