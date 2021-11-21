using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HrApp.Interfaces.Persistence;
using HrApp.Models;
using HrApp.Persistence.EfCore;
using Microsoft.EntityFrameworkCore;

namespace HrApp.Persistence.Repository
{
    public class AddressRepo : IAddressRepo
    {
        private readonly HrAppContext hrAppContext;

        public AddressRepo(HrAppContext _hrAppContext)
        {
            hrAppContext = _hrAppContext;
        }

        public IQueryable<Address> GetAddressesQueryable(Guid employeeId)
        {
            var addressesQuery = hrAppContext.Addresses.Where(a => a.IsActive && a.EmployeeId == employeeId);
            return addressesQuery;
        }
        
        public async Task<Address> GetAddressAsync(Guid addressId)
        {
            var dbAddress = await hrAppContext.Addresses
                .Where(a => a.IsActive && a.Id == addressId)
                .FirstOrDefaultAsync();
            return dbAddress;
        }

        public async Task AddAddressAsync(Address address)
        {
            await hrAppContext.AddAsync(address);
            await hrAppContext.SaveChangesAsync();
        }

        public async Task UpdateAddressAsync()
        {
            await hrAppContext.SaveChangesAsync();
        }
    }
}
