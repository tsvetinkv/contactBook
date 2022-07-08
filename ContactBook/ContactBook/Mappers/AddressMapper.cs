using ContactBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Mappers
{
    public class AddressMapper
    {
        public static Address mapStringToAddress(string strAddress)
        {
            if (string.IsNullOrWhiteSpace(strAddress))
            {
                throw new Exception("strAddress is null --> MapStringToAddress");
            }

            string[] address = strAddress.Split("/");

            return new Address()
            {
                ID = long.Parse(address[0]),
                Country = address[1],
                PostCode = address[2],
                City = address[3],
                StreetName = address[4],
                StreetNumber = address[5],
                ContactID = long.Parse(address[6])
            };
        }
    }
}
