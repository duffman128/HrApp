using HrApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Interfaces.BusinessRules
{
    public interface IAddressRules
    {
        public Task<IEnumerable<Address>> GetAddresseseAsync(Guid employeeId);
        public Task AddAddressAsync(Address address);
        public Task UpdateAddressAsync(Address address);
    }
}
