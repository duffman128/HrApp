using HrApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Interfaces.Persistence
{
    public interface IContactDetailRepo
    {
        public Task<ContactDetail> GetContactDetailAsync(Guid contactDetailId);
        public IQueryable<ContactDetail> GetContactDetailsQueryable(Guid employeeId);
        public Task AddContactDetailAsync(ContactDetail contactDetail);
        public Task UpdateContactDetailAsync();
    }
}
