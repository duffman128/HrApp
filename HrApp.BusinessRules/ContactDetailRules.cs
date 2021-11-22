using HrApp.Interfaces.BusinessRules;
using HrApp.Interfaces.Persistence;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HrApp.BusinessRules
{
    public class ContactDetailRules : IContactDetailRules
    {
        private readonly IContactDetailRepo contactDetailRepo;

        public ContactDetailRules(IContactDetailRepo _contactDetailRepo)
        {
            contactDetailRepo = _contactDetailRepo;
        }

        public async Task<IEnumerable<ContactDetail>> GetContactDetailsAsync(Guid employeeId)
        {
            if (employeeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            var contactDetails = await contactDetailRepo.GetContactDetailsQueryable(employeeId).ToListAsync();
            return contactDetails;
        }

        private Regex GetContactDetailTypeRegex(ContactDetailType contactDetailType)
        {
            switch (contactDetailType)
            {
                case ContactDetailType.Cellphone:
                case ContactDetailType.Landline:
                    return new Regex("^(+27|0)[1-8][0-9]{8}$");
                case ContactDetailType.Email:
                    return new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                case ContactDetailType.Social_Media:
                    return new Regex(@"^((ftp|http|https):\/\/)?$");
            }
            throw new ArgumentOutOfRangeException("ContactDetailType enum does not exist");
        }

        public async Task AddContactDetailAsync(ContactDetail contactDetail)
        {
            CheckContactDetail(contactDetail);

            var doesContactDetailExist = await contactDetailRepo.
                GetContactDetailsQueryable(contactDetail.EmployeeId).Where(c => c.ContactInfo == contactDetail.ContactInfo)
                .Take(1).AnyAsync();

            if (!doesContactDetailExist)
            {
                await contactDetailRepo.AddContactDetailAsync(contactDetail);
                return;
            }

            throw new ArgumentException("Employee contact info already exists.");
        }

        public async Task UpdateContactDetailAsync(ContactDetail contactDetail)
        {
            CheckContactDetail(contactDetail);

            var dbContactDetail = await contactDetailRepo.GetContactDetailAsync(contactDetail.Id);

            if (dbContactDetail is not null)
            {
                dbContactDetail.ContactInfo = contactDetail.ContactInfo;
                dbContactDetail.Type = contactDetail.Type;
                dbContactDetail.TimeStampModified = DateTime.Now;

                await contactDetailRepo.UpdateContactDetailAsync();
            }
            throw new ArgumentException("Employee contact info already exists.");
        }

        private void CheckContactDetail(ContactDetail contactDetail)
        {
            if (contactDetail is null)
            {
                throw new ArgumentNullException(nameof(contactDetail));
            }

            if (!GetContactDetailTypeRegex(contactDetail.Type).IsMatch(contactDetail.ContactInfo))
            {
                throw new ArgumentException($"Invalid {contactDetail.Type.ToString().Replace('_', ' ')} '{contactDetail.ContactInfo}'.");
            }
        }
    }
}
