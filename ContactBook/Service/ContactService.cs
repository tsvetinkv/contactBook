using ContactBook.Models;
using ContactBook.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Service
{
    public class ContactService
    {
        private PhoneRepository phoneRepository;
        private AddressRepository addressRepository;
        private ContactRepository contactRepository;
    
        public ContactService()
        {
            this.contactRepository = new ContactRepository();
            this.phoneRepository = new PhoneRepository();
            this.addressRepository = new AddressRepository();
        }
             public Contact AddOrUpdateContact(Contact contact)
        {
            if (contact == null)
            {
                throw new Exception("Contact is invalid!");
            }
            if (string.IsNullOrEmpty(contact.FirstName) && contact.FirstName.Length < 3)
            {
                throw new Exception("Contact name is invalid!");
            }

            if (string.IsNullOrEmpty(contact.MiddleName) && contact.MiddleName.Length < 3)
            {
                throw new Exception("Contact midlle name is invalid!");
            }
            if (string.IsNullOrEmpty(contact.LastName) && contact.LastName.Length < 3)
            {
                throw new Exception("Contact last name is invalid!");
            }
            if (contact.Age <= 0)
            {
                throw new Exception("Contact age can not be under 0!");
            }
            if (string.IsNullOrEmpty(contact.Email) && contact.Email.Length < 10)
            {
                throw new Exception("Contact email is invalid!");
            }
          //  foreach (var phone in contact.Phones)
          //  {
          //      this.phoneService.AddOrUpdatePhone(phone);
          //  }
          //foreach (var address in contact.Addreses)
          //  {
          //      this.addressService.AddOrUpdateAdress(address);
       
          //   }

            Contact newContact = this.contactRepository.AddOrUpdate(contact);
            return newContact;
        }

        public bool DeleteContact(long contactID)
        {
            if (this.phoneRepository.DeletePhones(contactID) && this.addressRepository.DeleteAddresses(contactID))
            {
                if (this.contactRepository.DeleteContact(contactID))
                {
                    return true;
                }
            }

            return false;
        }

        public List<Contact> GetContact()
        {
            return this.contactRepository.GetAllContacts();
        }
    }


}

