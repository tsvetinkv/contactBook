using ContactBook.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactBook.Models
{
    public class Phone
    {
        public long ID { get; set; }
        public TypePhones Type{ get; set; }
        public string Number { get; set; }

        public long ContactID { get; set; }
    }
}
