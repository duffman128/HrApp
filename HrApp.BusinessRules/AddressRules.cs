using HrApp.Interfaces.BusinessRules;
using HrApp.Interfaces.Persistence;
using HrApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.BusinessRules
{
    public class AddressRules : IAddressRules
    {
        private readonly IAddressRepo addressRepo;

        public AddressRules(IAddressRepo _addressRepo)
        {
            addressRepo = _addressRepo;
        }

        public async Task<IEnumerable<Address>> GetAddresseseAsync(Guid employeeId)
        {
            var addresses = await addressRepo.GetAddressesQueryable(employeeId).ToListAsync();
            return addresses;
        }

        public async Task AddAddressAsync(Address address)
        {
            if (address is null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            await addressRepo.AddAddressAsync(address);
        }

        public async Task UpdateAddressAsync(Address address)
        {
            if (address is null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            var dbAddress = await addressRepo.GetAddressAsync(address.Id);
            if (dbAddress is not null)
            {
                dbAddress.StreetNumber = address.StreetNumber;
                dbAddress.StreetName = address.StreetName;
                dbAddress.ComplexName = address.ComplexName;
                dbAddress.ComplexNumber = address.ComplexNumber;
                dbAddress.Suburb = address.Suburb;
                dbAddress.City = address.City;
                dbAddress.PostalCode = address.PostalCode;
                dbAddress.IsSameAsResidential = address.IsSameAsResidential;
                dbAddress.Type = address.Type;
                dbAddress.TimeStampModified = DateTime.Now;

                await addressRepo.UpdateAddressAsync();
                return;
            }
            throw new ArgumentException("Employee does not exist.");
        }
    }
}
