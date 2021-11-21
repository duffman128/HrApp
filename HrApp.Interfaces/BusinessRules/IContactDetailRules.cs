using HrApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Interfaces.BusinessRules
{
    public interface IContactDetailRules
    {
        public Task<IEnumerable<ContactDetail>> GetContactDetailsAsync(Guid employeeId);
        public Task AddContactDetailAsync(ContactDetail contactDetail);
        public Task UpdateContactDetailAsync(ContactDetail contactDetail);
    }
}
