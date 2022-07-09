using ContactBook.Models;
using ContactBook.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Mappers
{
    public class ContactMapper
    {
        public static Contact mapStringToContact(string strContact)
        {
            if (string.IsNullOrWhiteSpace(strContact))
            {
                throw new Exception("strContact is null --> MapStringToContact");
            }

            string[] contact = strContact.Split("/");

            return new Contact()
            {
                ID = long.Parse(contact[0]),
                FirstName = contact[1],
                MiddleName = contact[2],
                LastName = contact[3],
                Age = int.Parse(contact[4]),
                Email = contact[5],
                Gender = (GenderTypes)Enum.Parse(typeof(GenderTypes), contact[6])


            };
        }
    }
}

