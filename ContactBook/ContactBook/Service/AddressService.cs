using ContactBook.Models;
using ContactBook.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Service
{
    public class AddressService
    {
       
        private AddressRepository addressRepository;
        
        public AddressService()
        {
            this.addressRepository = new AddressRepository();
        }
        public Address AddOrUpdateAdress(Address address)
        {
            if(address == null)
            {
                throw new Exception("Address is invalid!");
            }
            if(string.IsNullOrEmpty(address.City)&& address.City.Length < 3)
            {
                throw new Exception("City is invalid!");

            }
            if (string.IsNullOrEmpty(address.Country) && address.Country.Length < 3)
            {
                throw new Exception("Country is invalid!");

            }
            if (string.IsNullOrEmpty(address.PostCode) && address.PostCode.Length < 4)
            {
                throw new Exception("Post code is invalid!");

            }
            if (string.IsNullOrEmpty(address.StreetName) && address.StreetName.Length < 3)
            {
                throw new Exception("Street name is invalid!");

            }
            if (string.IsNullOrEmpty(address.StreetNumber) && address.StreetNumber.Length < 1)
            {
                throw new Exception("Street number is invalid!");

            }
            Address newAddress = this.addressRepository.AddOrUpdate(address);
            return address;
        }
        public List<Address> GetAddress()
        {
            return this.addressRepository.GetAllAddresses();
        }

        public bool DeleteAddress(long addressID)
        {
            if (this.addressRepository.DeleteAddress(addressID))
            {
                return true;
            }

            return false;
        }
    }
}
