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
    public class ContactDetailRepo : IContactDetailRepo
    {
        private readonly HrAppContext hrAppContext;

        public ContactDetailRepo(HrAppContext _hrAppContext)
        {
            hrAppContext = _hrAppContext;
        }

        public async Task AddContactDetailAsync(ContactDetail contactDetail)
        {
            await hrAppContext.ContactDetails.AddAsync(contactDetail);
            await hrAppContext.SaveChangesAsync();
        }

        public async Task<ContactDetail> GetContactDetailAsync(Guid contactDetailId)
        {
            var contactDetail = await hrAppContext.ContactDetails
                .Where(c => c.IsActive && c.Id == contactDetailId)
                .FirstOrDefaultAsync();
            return contactDetail;
        }

        public IQueryable<ContactDetail> GetContactDetailsQueryable(Guid employeeId)
        {
            var contactDetailsQuery = hrAppContext.ContactDetails.Where(c => c.IsActive && c.EmployeeId == employeeId);
            return contactDetailsQuery;
        }

        public async Task UpdateContactDetailAsync()
        {
            await hrAppContext.SaveChangesAsync();
        }
    }
}
