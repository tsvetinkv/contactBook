using ContactBook.Models;
using ContactBook.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Mappers
{
    public class PhoneMapper
    {
        public static Phone mapStringToPhone(string strPhone)
        {
            if (string.IsNullOrWhiteSpace(strPhone))
            {
                throw new Exception("strPhone is null --> MapStringToPhone");
            }

            string[] phone = strPhone.Split("/");

            return new Phone()
            {
                ID = long.Parse(phone[0]),
                Number = phone[1],
                Type = (TypePhones)Enum.Parse(typeof(TypePhones),phone[2]),
                ContactID = long.Parse(phone[3])
            };
        }
    }
}
