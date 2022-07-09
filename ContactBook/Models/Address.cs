using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Models
{
    public class Address
    {
        public long ID { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        
        public long ContactID { get; set; }

    }
}
