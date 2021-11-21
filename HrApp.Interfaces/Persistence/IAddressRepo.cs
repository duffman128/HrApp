using HrApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Interfaces.Persistence
{
    public interface IAddressRepo
    {
        public IQueryable<Address> GetAddressesQueryable(Guid employeeId);
        public Task<Address> GetAddressAsync(Guid addressId);
        public Task AddAddressAsync(Address address);
        public Task UpdateAddressAsync();
    }
}
