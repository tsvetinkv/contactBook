using ContactBook.Models;
using ContactBook.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Service
{
    public class PhoneService
    {
        private PhoneRepository phoneRepository;
        public PhoneService()
        {
            this.phoneRepository = new PhoneRepository();
        }

        public Phone AddOrUpdatePhone(Phone phone)
        {
            if(phone == null)
            {
                throw new Exception("Phone is invalid!");

            }
            if (string.IsNullOrEmpty(phone.Number) && phone.Number.Length < 10)
            {
                throw new Exception("Number is invalid!");
            }

            Phone newPhone = this.phoneRepository.AddOrUpdate(phone);
            return phone;
        }
        public List<Phone> GetPhone()
        {
            return this.phoneRepository.GetAllPhones();
        }
        public PhoneService GetPhoneByID(long phoneID)
        {
            return null;
        }

        public bool DeletePhone(long phoneID)
        {
            if (this.phoneRepository.DeletePhone(phoneID))
            {
                return true;
            }

            return false;
        }
    }
}
